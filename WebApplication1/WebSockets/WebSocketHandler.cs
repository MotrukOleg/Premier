using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;
using WebApplication1.DTO;

namespace WebApplication1.WebSockets
{
    public class WebSocketHandler
    {
        private readonly List<string> _messageHistory = new();
        private readonly object _historyLock = new();
        private readonly ConcurrentDictionary<string, WebSocket> _connections = new();
        private readonly IConfiguration _configuration;

        public WebSocketHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task HandleConnectionAsync(HttpContext context)
        {

            var token = context.Request.Query["access_token"].ToString();
            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            // Validate the token and set the user
            var principal = ValidateToken(token);
            if (principal == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            context.User = principal;

            if (!context.User.Identity?.IsAuthenticated ?? true)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            string? userName =
                context.User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value ??
                context.User.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value ??
                context.User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
                userName = "Unknown";

            if (context.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                var connectionId = Guid.NewGuid().ToString();
                _connections.TryAdd(connectionId, webSocket);

                List<string> historyCopy;
                lock (_historyLock)
                {
                    historyCopy = new List<string>(_messageHistory);
                }

                foreach (var msg in historyCopy)
                {
                    var msgBuffer = System.Text.Encoding.UTF8.GetBytes(msg);
                    await webSocket.SendAsync(new ArraySegment<byte>(msgBuffer), WebSocketMessageType.Text, true,
                        CancellationToken.None);
                }

                await ReceiveLoop(connectionId, webSocket, userName);

                _connections.TryRemove(connectionId, out _);
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }


        private async Task ReceiveLoop(string connectionId, WebSocket webSocket, string userName)
        {
            var buffer = new byte[1024 * 4];
            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by client", CancellationToken.None);
                }
                else
                {
                    var json = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);

                    ChatMessageDto? chatMessage = null;
                    try
                    {
                        chatMessage = JsonConvert.DeserializeObject<ChatMessageDto>(json);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalid message format: {ex.Message}");
                        continue;
                    }

                    if (chatMessage != null)
                    {
                        var outgoingMessage = new ChatMessageDto
                        {
                            Text = chatMessage.Text,
                            ClientId = chatMessage.ClientId,
                            Name = userName
                        };
                        var jsonToSend = JsonConvert.SerializeObject(outgoingMessage);
                        var messageBuffer = System.Text.Encoding.UTF8.GetBytes(jsonToSend);

                        await BroadcastAsync(messageBuffer, messageBuffer.Length, result.MessageType, result.EndOfMessage, connectionId);
                    }
                }
            }
        }

        private async Task BroadcastAsync(byte[] buffer, int count, WebSocketMessageType messageType, bool endOfMessage,
            string senderId)
        {
            var message = System.Text.Encoding.UTF8.GetString(buffer, 0, count);

            lock (_historyLock)
            {
                _messageHistory.Add(message);
            }

            foreach (var pair in _connections)
            {
                if (pair.Value.State == WebSocketState.Open)
                {
                    try
                    {
                        await pair.Value.SendAsync(new ArraySegment<byte>(buffer, 0, count), messageType, endOfMessage,
                            CancellationToken.None);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }

        private ClaimsPrincipal? ValidateToken(string token)
        {
            var key = _configuration["Token:Key"];
            var issuer = _configuration["Token:Issuer"];
            var audience = _configuration["Token:Audience"];

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
                throw new Exception("Token validation parameters are not set in configuration!");

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}

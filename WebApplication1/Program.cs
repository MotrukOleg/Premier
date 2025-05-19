using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Chains;
using WebApplication1.Interfaces;
using WebApplication1.Services;
using WebApplication1.WebSockets;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<StadiumService, StadiumService>();
builder.Services.AddScoped<MatchInfoService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddSingleton<WebSocketHandler>();
builder.Services.AddHttpLogging(o => { });
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 30))).LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = 401;
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Unauthorized: This method is not allowed for unauthorized users" +
                                               "(Bearer JWT Tokens)");
        }
    };
});

var app = builder.Build();
var webSocketHandler = app.Services.GetRequiredService<WebSocketHandler>();
app.UseWebSockets();
app.Map("/ws" , webSocketHandler.HandleConnectionAsync);

app.UseHttpLogging();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
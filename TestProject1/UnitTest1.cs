using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.DTO;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Services;

namespace TestProject1

{
    public class ClubControllerTests
    {
        public readonly Mock<IClubService> club_service;
        private readonly ClubController clubController;
        public ClubControllerTests()
        {
            club_service = new Mock<IClubService>();
            clubController = new ClubController(club_service.Object);
        }

        [Fact]
        public async Task Get_ClubsShouldReturnOkAndTwoClubs()
        {
                var clubs = new List<OutputClubDto>
            {
                new OutputClubDto { id = 1, name = "Club A" },
                new OutputClubDto { id = 2, name = "Club B" }
            };
            club_service.Setup(club => club.Get()).ReturnsAsync(clubs);


            var result = await clubController.Get();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedClubs = Assert.IsType<List<OutputClubDto>>(okResult.Value);
            Assert.Equal(2 , returnedClubs.Count());
        }
        [Fact]
        public async Task Post_ResultCreationAtAction_WithNewClub()
        {
            var input = new InputClubDto { name = "New Club" };
            var club = new OutputClubDto { id = 1, name = "New Club" };
            club_service.Setup(club => club.Post(input)).ReturnsAsync(club);

            var result = await clubController.Post(input);

            var okResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedClub = Assert.IsType<Club>(okResult.Value);
            Assert.Equal(1, returnedClub.Id);
        }
        [Fact]
        public async Task Post_ReturnsBadRequest_WhenInputIsInvalid()
        {
            InputClubDto input = null;

            var result = await clubController.Post(input);

            Assert.IsType<BadRequestResult>(result.Result);
        }
    }
}

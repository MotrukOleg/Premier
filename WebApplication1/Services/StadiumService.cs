using Microsoft.EntityFrameworkCore;
using WebApplication1.Chains;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StadiumService
    {
        private readonly AppDbContext context;

        public StadiumService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<OutputStadiumDto>> Get()
        {
            List<Stadium> stadiums = await context.Stadium.Include(stadium => stadium.Club).ToListAsync();
            List<OutputStadiumDto> outputStadiums = stadiums.Select(stadium => (OutputStadiumDto)stadium).ToList();
            return outputStadiums;
        }

        public async Task<Stadium> Post(InputStadiumDto? input)
        {
            Stadium stadium = new Stadium
            {
                Id = input.id,
                Name = input.Name,
                City = input.City,
                Country = input.Country,
                Capacity = input.Capacity,
            };
            context.Stadium.Add(stadium);
            await context.SaveChangesAsync();

            return stadium;
        }

        public async Task<OutputStadiumDto> GetById(int id)
        {
            Stadium? stadium = await context.Stadium.Include(stadium => stadium.Club).FirstOrDefaultAsync(club => club.Id == id);


            return (OutputStadiumDto)stadium;
        }
    }
}

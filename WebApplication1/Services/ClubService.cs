using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Chains;
using WebApplication1.DTO;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services



{
    public class ClubService : IClubService
    {
        private readonly AppDbContext context;
        
        public ClubService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<OutputClubDto>> Get()
        {
            List<Club> clubs = await context.Club.Include(club => club.Stadium).ToListAsync();
            List<OutputClubDto> outputClubs = clubs.Select(club => (OutputClubDto)club).ToList();
            return outputClubs;
        }

        public async Task<OutputClubDto> Post(InputClubDto? input)
        {
            Club club = new Club
            {
                Id = input.id,
                Name = input.name,
                Coach = input.coach,
                City = input.city,
                Country = input.country,
                StadiumId = input.stadiumId,
            };
            Stadium? stadium = await context.Stadium.FirstOrDefaultAsync(Stadium => Stadium.Id == club.StadiumId);
            PostStadiumToClub(stadium, club.StadiumId);
            context.Entry(stadium).State = EntityState.Modified;


            context.Club.Add(club);
            await context.SaveChangesAsync();

            return (OutputClubDto)club;
        }

        public async Task<OutputClubDto> GetById(int id)
        {
            Club? club = await context.Club.Include(club => club.Stadium).FirstOrDefaultAsync(club => club.Id == id);

            return (OutputClubDto)club;
        }

        public async Task<OutputClubDto?> Put(InputClubDto input , int id)
        {
            Club? club = await context.Club.Include(club => club.Stadium).FirstOrDefaultAsync(club => club.Id == id);
            if(club == null)
            {
                return null;
            }
            UpdateClub(club, input);

            context.Entry(club).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return (OutputClubDto)club;

        }

        private void UpdateClub(Club club, InputClubDto input)
        {
            club.Name = input.name;
            club.Coach = input.coach;
            club.StadiumId = input.stadiumId;
            club.City = input.city;
            club.Founded = input.founded;
        }
        private void PostStadiumToClub(Stadium? stadium , int  id)
        {
            stadium.ClubId = id;
        }

    }
}

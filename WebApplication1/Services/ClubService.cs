using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Chains;
using WebApplication1.DTO;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class ClubService : IClubService
{
    private readonly AppDbContext _context;

    public ClubService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<OutputClubDto>> Get()
    {
        List<Club> clubs = await _context.Club.Include(club => club.Stadium).ToListAsync();
        List<OutputClubDto> outputClubs = clubs.Select(club => (OutputClubDto)club).ToList();
        return outputClubs;
    }

    public async Task<OutputClubDto> Post(InputClubDto? input)
    {
        Club? club = new Club
        {
            Id = input.id,
            Name = input.name,
            Coach = input.coach,
            City = input.city,
            Country = input.country,
            StadiumId = input.stadiumId,
        };
        Stadium? stadium = await _context.Stadium.FirstOrDefaultAsync(Stadium => Stadium.Id == club.StadiumId);
        PostStadiumToClub(stadium, club.StadiumId);
        _context.Entry(stadium).State = EntityState.Modified;


        _context.Club.Add(club);
        await _context.SaveChangesAsync();

        return (OutputClubDto)club;
    }

    public async Task<OutputClubDto> GetById(int id)
    {
        Club? club = await _context.Club.Include(club => club.Stadium).FirstOrDefaultAsync(club => club != null && club.Id == id);


        var goalConceded = 0;
        var goalScored = 0;

        var matches = await _context.MatchInfo.Include(homeClub => homeClub.HomeClub)
            .Include(awayClub => awayClub.AwayClub)
            .Where(match => (match != null && match.HomeClubId == id) || match.AwayClubId == id)
            .ToListAsync();

        foreach (var matchInfo in matches.Where(matchInfo =>
                     matchInfo.HomeClubId == id || matchInfo.AwayClubId == id))
        {
            goalScored += matchInfo.HomeTeamGoals;
            goalConceded += matchInfo.AwayTeamGoals;
        }

        var dto = (OutputClubDto)club;

        dto.GoalScored = goalScored;
        dto.GoalConceded = goalConceded;

        return dto;
    }

    public async Task<OutputClubDto?> Put(InputClubForWeb input, int id)
    {
        Club? club = await _context.Club.Include(club => club.Stadium).FirstOrDefaultAsync(club => club.Id == id);
        if (club == null)
        {
            return null;
        }

        UpdateClub(club, input);

        _context.Entry(club).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return (OutputClubDto)club;
    }

    public async Task<Club?> Delete(int id)
    {
        Club? clubToDelete = await _context.Club.FirstOrDefaultAsync(club => club.Id == id);

        if (clubToDelete != null)
        {
            _context.Remove(clubToDelete);
            await _context.SaveChangesAsync();
            return clubToDelete;
        }

        return null;
    }

    public async Task<OutputClubDto?> GetOldestClub()
    {
        Club? oldestClub = await _context.Club.Include(club => club.Stadium).OrderBy(club => club!.Founded).FirstOrDefaultAsync();

        return (OutputClubDto)oldestClub;
    }

    private static void UpdateClub(Club club, InputClubForWeb input)
    {
        club.Name = input.name;
        club.Coach = input.coach;
        club.City = input.city;
        club.Founded = input.founded;
    }

    private static void PostStadiumToClub(Stadium? stadium, int id)
    {
        if (stadium != null) stadium.ClubId = id;
    }
}
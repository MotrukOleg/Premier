using Microsoft.EntityFrameworkCore;
using WebApplication1.Chains;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class MatchInfoService
{
    private readonly AppDbContext _context;

    public MatchInfoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MatchInfo>> Get()
    {
        var matches = await _context.MatchInfo.Include(homeClub => homeClub.HomeClub)
            .Include(awayClub => awayClub.AwayClub).ToListAsync();


        return matches;
    }

    public async Task<MatchInfo> GetById(int id)
    {
        var match = await _context.MatchInfo.Include(homeClub => homeClub.HomeClub)
            .Include(awayClub => awayClub.AwayClub)
            .FirstOrDefaultAsync(match => (match != null && match.HomeClubId == id) || match.AwayClubId == id);

        return match;
    }

    public async Task<List<MatchInfo>> GetAllById(int id)
    {

        var matches = await _context.MatchInfo.Include(homeClub => homeClub.HomeClub)
            .Include(awayClub => awayClub.AwayClub)
            .Where(match => (match != null && match.HomeClubId == id) || match.AwayClubId == id)
            .ToListAsync();



        return matches;
    }
}
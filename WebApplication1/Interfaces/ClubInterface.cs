using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IClubService
    {
        Task<List<OutputClubDto>> Get();
        Task<OutputClubDto> GetById(int id);
        Task<OutputClubDto> Post(InputClubDto input);
        Task<OutputClubDto?> Put(InputClubForWeb input, int id);
        Task<Club?> Delete(int id);
        Task<OutputClubDto?> GetOldestClub();

    }
}

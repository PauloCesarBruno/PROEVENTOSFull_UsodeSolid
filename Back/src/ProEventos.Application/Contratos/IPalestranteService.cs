using System.Threading.Tasks;
using ProEventos.Application.Dtos;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IPalestranteService
    {
        Task<PalestranteDto> AddPalestrantes(PalestranteDto model);
        Task<PalestranteDto> UpdatePalestrantes(int palestranteId, PalestranteDto model);
        Task<bool> DeletePalestrantes(int palestranteId);
        
        Task<PalestranteDto[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<PalestranteDto[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);
        Task<PalestranteDto> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);
    }
}
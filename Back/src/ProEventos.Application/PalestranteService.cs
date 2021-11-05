using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class PalestranteService : IPalestranteService
    {

        private readonly IGeralPersist _geralPersist;
        private readonly IPalestrantePersist _palestrantePersist;
         private readonly IMapper _mapper;
        public PalestranteService(IGeralPersist geralPersist,
                                  IPalestrantePersist palestrantePersist,
                                  IMapper mapper)
        {
            _palestrantePersist = palestrantePersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
        }

        public async Task<PalestranteDto> AddPalestrantes(PalestranteDto model)
        {
            try
            {
                 var palestrante = _mapper.Map<Palestrante>(model);
    
                _geralPersist.Add<Palestrante>(palestrante);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var palestranteRetorno = await _palestrantePersist.GetPalestranteByIdAsync(palestrante.Id, false);

                    return _mapper.Map<PalestranteDto>(palestranteRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {                
                throw new Exception (ex.Message);
            }
        }

        public async Task<PalestranteDto> UpdatePalestrantes(int palestranteId, PalestranteDto model)
        {
            try
            {
                var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(palestranteId, false);
                if (palestrante == null) return null;

                model.Id = palestrante.Id;

                _mapper.Map(model, palestrante);

                _geralPersist.Update<Palestrante>(palestrante);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var palestranteRetorno = await _palestrantePersist.GetPalestranteByIdAsync(palestrante.Id, false);

                    return _mapper.Map<PalestranteDto>(palestranteRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                 throw new Exception (ex.Message);
            }
        }

        public async Task<bool> DeletePalestrantes(int palestranteId)
        {
            try
            {
                var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(palestranteId, false);
                if (palestrante == null) throw new Exception ("Palestrante para deleção não encontrado !");

                _geralPersist.Delete<Palestrante>(palestrante);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                 throw new Exception (ex.Message);
            }
        }

        // ==============================================================================================

        public async Task<PalestranteDto[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersist.GetAllPalestrantesAsync(includeEventos);
                if (palestrantes == null) return null;

                 var resultado = _mapper.Map<PalestranteDto[]>(palestrantes);

                return resultado;
            }
            catch (Exception ex)
            {                
                 throw new Exception (ex.Message);
            }
        }

        public async Task<PalestranteDto[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersist.GetAllPalestrantesByNomeAsync(tema, includeEventos);
                if (palestrantes == null) return null;

                 var resultado = _mapper.Map<PalestranteDto[]>(palestrantes);

                return resultado;
            }
            catch (Exception ex)
            {                
                 throw new Exception (ex.Message);
            }
        }

        public async Task<PalestranteDto> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersist.GetPalestranteByIdAsync(palestranteId, includeEventos);
                if (palestrantes == null) return null;

                 var resultado = _mapper.Map<PalestranteDto>(palestrantes);

                return resultado;
            }
            catch (Exception ex)
            {                
                 throw new Exception (ex.Message);
            }
        }       
    }
}
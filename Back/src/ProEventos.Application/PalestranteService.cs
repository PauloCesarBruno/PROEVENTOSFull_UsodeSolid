using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class PalestranteService : IPalestranteService
    {

        private readonly IGeralPersist _geralPersist;
        private readonly IPalestrantePersist _palestrantePersist;
        public PalestranteService(IGeralPersist geralPersist, IPalestrantePersist palestrantePersist)
        {
            _palestrantePersist = palestrantePersist;
            _geralPersist = geralPersist;

        }

        public async Task<Palestrante> AddPalestrantes(Palestrante model)
        {
            try
            {
                _geralPersist.Add<Palestrante>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _palestrantePersist.GetPalestranteByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {                
                throw new Exception (ex.Message);
            }
        }

        public async Task<Palestrante> UpdatePalestrantes(int palestranteId, Palestrante model)
        {
            try
            {
                var palestrante = await _palestrantePersist.GetPalestranteByIdAsync(palestranteId, false);
                if (palestrante == null) return null;

                model.Id = palestrante.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _palestrantePersist.GetPalestranteByIdAsync(model.Id, false);
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

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersist.GetAllPalestrantesAsync(includeEventos);
                if (palestrantes == null) return null;

                return palestrantes;
            }
            catch (Exception ex)
            {                
                 throw new Exception (ex.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersist.GetAllPalestrantesByNomeAsync(tema, includeEventos);
                if (palestrantes == null) return null;

                return palestrantes;
            }
            catch (Exception ex)
            {                
                 throw new Exception (ex.Message);
            }
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            try
            {
                var palestrantes = await _palestrantePersist.GetPalestranteByIdAsync(palestranteId, includeEventos);
                if (palestrantes == null) return null;

                return palestrantes;
            }
            catch (Exception ex)
            {                
                 throw new Exception (ex.Message);
            }
        }       
    }
}
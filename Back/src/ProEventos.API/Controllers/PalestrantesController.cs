using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PalestrantesController : ControllerBase
    {
        private readonly IPalestranteService _palestranteService;
        public PalestrantesController(IPalestranteService palestranteService)
        {
           _palestranteService = palestranteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var palestrantes = await _palestranteService.GetAllPalestrantesAsync(true);
                if (palestrantes == null) return NotFound("Nenhum palestrantes encontrado !");

                return Ok(palestrantes);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar palestrantes !. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var palestrantes = await _palestranteService.GetPalestranteByIdAsync(id, true);
                if (palestrantes == null) return NotFound("Palestrante(s) por Código(Id) não encontrado(s) !");

                return Ok(palestrantes);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar palestrante !. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByTema(string nome)
        {
            try
            {
                var palestrantes = await _palestranteService.GetAllPalestrantesByNomeAsync(nome, true);
                if (palestrantes == null) return NotFound("Palestrante(s) por tema não encontrado(s) !");

                return Ok(palestrantes);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar palestrante !. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Palestrante model)
        {
            try
            {
                var palestrante = await _palestranteService.AddPalestrantes(model);
                if (palestrante == null) return BadRequest("Erro ao tentar adicionar palestrante !");

                return Ok(palestrante);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro: Erro ao tentar adicionar palestrante ! {ex.Message}");
            }
        }

        [HttpPut("{Id}")]
        public async Task <IActionResult> Put(int Id, Palestrante model)
        {
            try
            {
                var palestrante = await _palestranteService.UpdatePalestrantes(Id, model);
                if (palestrante == null) return BadRequest("Erro ao tentar alterar palestrante !");

                return Ok(palestrante);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro: Erro ao tentar alterar palestrante ! {ex.Message}");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
             return await _palestranteService.DeletePalestrantes(Id) ? 
                    Ok("Deletado com sucesso !") : 
                    BadRequest("Palestrante não pode ser deletado !");            
                                   
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro: Erro ao tentar excluir palestrante ! {ex.Message}");
            }
        }
    }
}
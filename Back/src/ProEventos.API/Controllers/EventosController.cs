using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.models;
// ====================================

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {       
        private readonly DataContext _context;

        public EventosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{Id}")]
        public Evento GetById(int Id)
        {
            return _context.Eventos.FirstOrDefault(e => e.EventoId == Id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{Id}")]
        public string Put(int Id)
        {
            return $"Exemplo de Put com Id = {Id}";
        }

        [HttpDelete("{Id}")]
        public string Delete(int Id)
        {
            return $"Exemplo de Delete com Id = {Id}";
        }
    }
}

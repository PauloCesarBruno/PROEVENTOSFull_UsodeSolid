using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.models;
// ====================================

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento =  new Evento[] {
                new Evento(){
                EventoId = 1,
                Tema = "Angular 11 e .NET 5",
                Local = "Belo Horizonte",
                Lote = "1º Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemURL = "foto.png"
                },

                new Evento(){
                EventoId = 2,
                Tema = "Angular e suas novidade",
                Local = "São Paulo",
                Lote = "2º Lote",
                QtdPessoas = 350,
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                ImagemURL = "foto1.png"
                }
            };   

        public EventoController()
        {            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento; 
        }

        [HttpGet("{Id}")]
        public IEnumerable<Evento> GetById(int Id)
        {
            return _evento.Where(e=> e.EventoId == Id);
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

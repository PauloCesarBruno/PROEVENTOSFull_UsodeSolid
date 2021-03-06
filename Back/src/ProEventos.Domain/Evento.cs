using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Domain
{    // Data Anotation de EF.Core para diferenciar meu codigo da Tabela do Banco de Dados, caso tenham nome diferentes.
    //[Table("EventosDetalhes")] 
    public class Evento
    {       
        public int Id { get; set; }
        public string Local { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }       
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        
        public IEnumerable<Lote> Lotes { get; set; }

        public IEnumerable<RedeSocial> RedesSociais { get; set; }

        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}
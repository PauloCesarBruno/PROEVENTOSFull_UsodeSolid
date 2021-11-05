using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        
        public int Id { get; set; }

        [Required (ErrorMessage = "O Campo {0} é obrigatório !")]
        public string Local { get; set; }

        public string DataEvento { get; set; }
        [Required (ErrorMessage = "O Campo {0} é obrigatório !"),
        StringLength(50, MinimumLength = 3,
                         ErrorMessage = "O Campo {0} deve ter entre 03 e 50 caracteres !")
        ]
        public string Tema { get; set; }

        [Required (ErrorMessage = "O Campo {0} é obrigatório !")]
        public int QtdPessoas { get; set; }  

        [Required (ErrorMessage = "O Campo {0} é obrigatório !")]     
        public string ImagemURL { get; set; }

        [Required (ErrorMessage = "O Campo {0} é obrigatório !")]
        public string Telefone { get; set; }

        [Required (ErrorMessage = "O Campo {0} é obrigatório !")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O E-Mail não está em um formato válido !")]
        public string Email { get; set; }
        
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }    
}
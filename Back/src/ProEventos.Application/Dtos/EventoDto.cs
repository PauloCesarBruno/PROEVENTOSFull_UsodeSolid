using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        
        public int Id { get; set; }

        [Required (ErrorMessage = "O Campo {0} é obrigatório !")]
        public string Local { get; set; }

        [Required (ErrorMessage = "O Campo {0} é Obrigatório !")]  
        public string DataEvento { get; set; } //  DateTime

        [Required (ErrorMessage = "O Campo {0} é obrigatório !"),
        StringLength(50, MinimumLength = 3,
                         ErrorMessage = "O Campo {0} deve ter entre 03 e 50 caracteres !")]
        public string Tema { get; set; }

        [Required (ErrorMessage = "O Campo {0} é obrigatório !"),
         Display(Name ="Qtd. Pessoas"),
         Range (1, 120000, ErrorMessage =" {0} não pode ser menor que 01 e maior que 120.000 !")]
        public int QtdPessoas { get; set; }  

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
                           ErrorMessage ="Não é uma imagem válida use imagens = (gif, jpg, jpeg, bmp ou png !)")]
        public string ImagemURL { get; set; }

        [Required (ErrorMessage = "O Campo {0} é obrigatório !"),
        Phone (ErrorMessage = "O Campo {0} não corresponde um número válido !")]
        public string Telefone { get; set; }

        [Required (ErrorMessage = "O Campo {0} é obrigatório !"),
         Display(Name ="e-mail"),
         DataType(DataType.EmailAddress),
         EmailAddress(ErrorMessage = "O E-Mail não está em um formato válido !")]
        public string Email { get; set; }
        
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }    
}
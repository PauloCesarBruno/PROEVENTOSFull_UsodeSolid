using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class PalestranteDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "O Campo {0} é Obrigatório !")]  
        public string Nome { get; set; }

        [Required (ErrorMessage = "O Campo {0} é Obrigatório !")]  
        public string MiniCurriculo { get; set; }

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

        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }

        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}
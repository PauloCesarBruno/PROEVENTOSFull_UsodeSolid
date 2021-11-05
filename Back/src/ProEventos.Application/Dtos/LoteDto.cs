using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "O Campo {0} é Obrigatório !")]      
        public string Nome { get; set; }

        [Required (ErrorMessage = "O Campo {0} é Obrigatório !")]     
        [DataType(DataType.Currency)] 
        public decimal preco { get; set; }

         [Required (ErrorMessage = "O Campo {0} é Obrigatório !")]      
        public string DataInicio { get; set; }

        [Required (ErrorMessage = "O Campo {0} é Obrigatório !")]      
        public string DataFim { get; set; }

        [Required (ErrorMessage = "O Campo {0} é Obrigatório !")]  
        public int Quantidade { get; set; }
        
        public int EventoId { get; set; }
        public EventoDto Evento { get; set; }
    }
}
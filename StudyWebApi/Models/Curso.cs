using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyWebApi.Models
{
    public class Curso
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Nome do curso deve ser informado.")]
        public string NomeCurso { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required(ErrorMessage = "Preço deve ser informado.")]
        public double? Preco { get; set; }

        public string? Descricao { get; set; }
        public bool Status { get; set; }    
        
    }
}

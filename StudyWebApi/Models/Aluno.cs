using StudyWebApi.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyWebApi.Models
{
    public class Aluno
    {

        public int ID { get; set; }

        [Display(Name = "Nome do Aluno")]
        [Required(ErrorMessage ="O nome do aluno é obrigatório.")]
        public string? Nome { get; set; }

        [Display(Name = "Status do Curso")]
        [Required(ErrorMessage = "O Status do Curso é obrigatório.")]
        public StatusCurso? StatusCurso { get; set; }

        [Display(Name = "Data de Ingresso")]
        [Required(ErrorMessage = "A data de ingresso é obrigatória.")]
        public DateTime? DataIngresso { get; set; }

        [Display(Name = "Curso")]
        public int IDCurso { get; set; }
        
        [ForeignKey("IDCurso")]
        public virtual Curso? Curso { get; set; }

        public int? UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }
    }
}

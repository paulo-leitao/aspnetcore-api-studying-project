using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploWEB_API.Models
{
    [Table("Curso")]
    public class Curso
    {
        [Key]
        public int ID {get;set;}
        [Required(ErrorMessage = "Informe a descrição do curso")]
        [StringLength(50)]
        public string Descricao {get;set;}
        [Required(ErrorMessage = "Informe a carga horária")]
        public int CargaHoraria {get;set;}
        
    }
}

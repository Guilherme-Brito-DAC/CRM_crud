using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Crud.Models
{
    public class Inscricao : BaseModel
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MinLength(5, ErrorMessage = "O nome tem que possuir no mínimo 5 caractéres")]
        [MaxLength(250, ErrorMessage = "O nome tem que possuir menos que 250 caractéres")]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Data")]
        public DateTime data { get; set; }
        [Required]
        [Display(Name = "Curso")]
        public int curso_id { get; set; }
        [Required]
        [Display(Name = "Lead")]
        public int lead_id { get; set; }
        [Display(Name = "Status")]
        public status status { get; set; }
    }

    public enum status
    {
        Inscrito,
        Classificado,
        Convocado,
        Matriculado
    }
}

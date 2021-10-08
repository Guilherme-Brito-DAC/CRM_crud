using System;
using System.ComponentModel.DataAnnotations;

namespace CRM_Crud.Models
{
    public class Inscricao : BaseModel
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MinLength(5, ErrorMessage = "O nome tem que possuir no mínimo 5 caractéres")]
        [MaxLength(250, ErrorMessage = "O nome tem que possuir menos que 250 caractéres")]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Data de inscrição")]
        public DateTime data_de_inscricao { get; set; }
        [Required]
        [Display(Name = "Curso")]
        public int curso_id { get; set; }
        [Required]
        [Display(Name = "Lead")]
        public int lead_id { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
    }

    public enum status
    {
        Inscrito,
        Classificado,
        Convocado,
        Matriculado
    }
}

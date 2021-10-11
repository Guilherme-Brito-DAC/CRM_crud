using System;
using System.ComponentModel.DataAnnotations;

namespace CRM_Crud.Models
{
    public class ViewInscricao : BaseModel
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MinLength(5, ErrorMessage = "O nome tem que possuir no mínimo 5 caractéres")]
        [MaxLength(250, ErrorMessage = "O nome tem que possuir menos que 250 caractéres")]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Data de inscrição")]
        public DateTime data_de_inscricao { get; set; }
        [Required(ErrorMessage = "O lead é obrigatório")]
        [Display(Name = "Lead")]
        public int lead_id { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        [Required(ErrorMessage = "O curso é obrigatório")]
        [Display(Name = "Curso")]
        public string curso { get; set; }
    }
}

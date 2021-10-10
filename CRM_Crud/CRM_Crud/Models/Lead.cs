using System.ComponentModel.DataAnnotations;

namespace CRM_Crud.Models
{
    public class Lead : BaseModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name ="Nome")]
        [MinLength(5, ErrorMessage = "O nome tem que possuir no mínimo 5 caractéres")]
        [MaxLength(250, ErrorMessage = "O nome tem que possuir menos que 250 caractéres")]
        public string nome { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email é obrigatório")]
        public string email { get; set; }
        [Required(ErrorMessage = "Telefone é obrigatório")]
        [Display(Name = "Telefone")]
        [MaxLength(11, ErrorMessage = "O Telefone tem que possuir menos que 11 caractéres")]
        public string telefone { get; set; }
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF é obrigatório")]
        [MinLength(11, ErrorMessage = "O CPF tem que possuir 11 caracteres")]
        [MaxLength(11, ErrorMessage = "O CPF tem que possuir 11 caractéres")]
        public string cpf { get; set; }
    }
}

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
        [MinLength(14, ErrorMessage = "O Telefone tem que possuir mais que 14 caracteres")]
        [MaxLength(15, ErrorMessage = "O Telefone tem que possuir menos que 15 caractéres")]
        public string telefone { get; set; }
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF é obrigatório")]
        [MinLength(14, ErrorMessage = "O CPF tem que possuir 14 caracteres")]
        [MaxLength(14, ErrorMessage = "O CPF tem que possuir 14 caractéres")]
        public string cpf { get; set; }
    }
}

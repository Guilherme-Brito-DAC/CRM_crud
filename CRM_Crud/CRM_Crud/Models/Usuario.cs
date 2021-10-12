using System.ComponentModel.DataAnnotations;

namespace CRM_Crud.Models
{
    public class Usuario : BaseModel
    {
        [Required(ErrorMessage = "O Login é obrigatório")]
        [Display(Name = "Login")]
        [MaxLength(250,ErrorMessage = "O Login deve ter no máximo 250 caracteres")]
        public string login { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [Display(Name = "Senha")]
        [MaxLength(250, ErrorMessage = "A senha deve ter no máximo 250 caracteres")]
        public string senha { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Crud.Models
{
    public class Lead : BaseModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "O nome tem que possuir no mínimo 5 caractéres")]
        [MaxLength(250, ErrorMessage = "O nome tem que possuir menos que 250 caractéres")]
        public string nome { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "O Telefone tem que possui no minimo 10 caracteres")]
        [MaxLength(11, ErrorMessage = "O Telefone tem que possuir menos que 11 caractéres")]
        public string telefone { get; set; }
        [Required]
        [MinLength(11, ErrorMessage = "O Telefone tem que possuir 11 caracteres")]
        [MaxLength(11, ErrorMessage = "O Telefone tem que possuir 11 caractéres")]
        public string cpf { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class Curso : BaseModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "O titulo tem que possuir no mínimo 5 caractéres")]
        [MaxLength(250, ErrorMessage = "O titulo tem que possuir menos que 250 caractéres")]
        [Display(Name = "Titulo")]
        public string titulo { get; set; }

        [Required]
        [Display(Name = "Data de Inicio")]
        public DateTime data_inicio { get; set; }

        [Required]
        [Display(Name = "Data de Termino")]
        public DateTime data_termino { get; set; }

        [Required]
        [Display(Name = "Periodo Letivo")]
        public string periodo_letivo { get; set; }

        public enum categoria
        {
            ENEM,
            CRM4U,
            Agendado,
            Tradicional
        }

        public DateTime data_criacao { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "A quantidade minima de vagas é 1")]
        [Display(Name = "Quantidade máxima de inscrições")]
        public int qnt_de_inscricoes = 100;
    }
}

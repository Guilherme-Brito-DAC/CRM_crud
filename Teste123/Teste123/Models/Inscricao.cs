using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class Inscricao : BaseModel
    {
        [Required]
        [MinLength(5, ErrorMessage = "O nome tem que possuir no mínimo 5 caractéres")]
        [MaxLength(250, ErrorMessage = "O nome tem que possuir menos que 250 caractéres")]
        public string nome { get; set; }
        [Required]
        public DateTime data { get; set; }
        public int lead_id { get; set; }
        public int curso_id { get; set; }
        public enum status
        {
            Inscrito,
            Classificado,
            Convocado,
            Matriculado
        }
    }
}

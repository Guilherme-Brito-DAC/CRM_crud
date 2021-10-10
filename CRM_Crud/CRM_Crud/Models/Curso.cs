using System;
using System.ComponentModel.DataAnnotations;

namespace CRM_Crud.Models
{
    public class Curso : BaseModel
    {
        [Required(ErrorMessage = "Título é obrigatório ")]
        [MinLength(5, ErrorMessage = "O titulo tem que possuir no mínimo 5 caractéres")]
        [MaxLength(250, ErrorMessage = "O titulo tem que possuir menos que 250 caractéres")]
        [Display(Name = "Título")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "Data de Inicio é obrigatório ")]
        [Display(Name = "Data de Inicio")]
        public DateTime data_inicio { get; set; }

        [Required(ErrorMessage = "Data de Termino é obrigatório ")]
        [Display(Name = "Data de Termino")]
        public DateTime data_termino { get; set; }

        [Required(ErrorMessage = "Periodo Letivo é obrigatório ")]
        [Display(Name = "Periodo Letivo")]
        public string periodo_letivo { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatório ")]
        [Display(Name = "Categoria")]
        public string categoria { get; set; }

        [Required(ErrorMessage = "Quantidade máxima de inscrições é obrigatório ")]
        [Display(Name = "Quantidade máxima de inscrições")]
        public int qnt_de_inscricoes { get; set; }
    }

    public enum Categoria
    {
        Agendado,
        ENEM,
        CRM4U,
        Tradicional
    }
}

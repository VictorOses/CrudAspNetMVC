using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CrudAspNetMvc.Attributes;

namespace CrudAspNetMvc.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo deve ser preenchido.")]
        [MaxLength(100, ErrorMessage = "Esse campo deve ter até 100 caracteres")]
        public string Nome { get; set; }

        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "Esse campo deve ser preenchido.")]
        [StringLength(14, ErrorMessage = "Esse campo deve ter 14 caracteres com pontos e traços.")]
        [CPFValido(ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }

        [MaxLength(100, ErrorMessage = "Esse campo deve ter até 100 caracteres.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Esse campo deve ser preenchido")]
        [MaxLength(100, ErrorMessage = "Esse campo deve ter ate 20 caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Esse campo deve ser preenchido.")]
        [MaxLength(100, ErrorMessage = "Esse campo deve ter até 100 caracteres.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Esse campo deve ser preenchido")]
        [MaxLength(100, ErrorMessage = "Esse campo deve ter ate 10 caracteres.")]
        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "Esse campo deve ter ate 10 caracteres.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Esse campo deve ser preenchido")]
        [MaxLength(100, ErrorMessage = "Esse campo deve ter ate 100 caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Esse campo deve ser preenchido")]
        [MaxLength(100, ErrorMessage = "Esse campo deve ter ate 100 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Esse campo deve ser preenchido.")]
        [StringLength(2, ErrorMessage = "Esse campo deve ter 2 caracteres (sigla do estado).")]
        public string Estado { get; set; }

        [Display(Name = "Estado Civil")]
        public EstadoCivil EstadoCivil { get; set; }
    }
}
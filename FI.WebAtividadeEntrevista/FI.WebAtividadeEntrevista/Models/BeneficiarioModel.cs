using FI.AtividadeEntrevista.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAtividadeEntrevista.CustonValidators;

namespace WebAtividadeEntrevista.Models
{
    public class BeneficiarioModel
    {
        public long ID { get; set; }
        [ValidateCpf(ErrorMessage ="CPF inválido")]

        public string Cpf { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage ="É necessário que o cliente seja cadastrado para incluir beneficiários")]
        public long IDCliente { get; set; }
    }
}
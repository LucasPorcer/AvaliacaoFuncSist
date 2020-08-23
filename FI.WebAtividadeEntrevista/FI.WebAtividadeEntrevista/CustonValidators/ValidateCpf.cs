using FI.WebAtividadeEntrevista.CrossCutting.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAtividadeEntrevista.CustonValidators
{
    public class ValidateCpf : ValidationAttribute, IClientValidatable
    {
        public ValidateCpf()
        {

        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = this.FormatErrorMessage(null),
                ValidationType = "validatecpf"
            };
        }

        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;

            bool valido = BrazilianDocumentsValidations.ValidateCpf(value.ToString());
            return valido;
            
        }
    }
}
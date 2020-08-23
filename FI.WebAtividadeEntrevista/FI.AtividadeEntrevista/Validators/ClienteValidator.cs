using FI.AtividadeEntrevista.DML;
using FI.WebAtividadeEntrevista.CrossCutting.Validators;
using FluentValidation;

namespace FI.AtividadeEntrevista.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {

            RuleFor(b => b.Cpf)
                .NotNullWithMessage()
                .Custom((cpf, context) =>
                {
                    if (!BrazilianDocumentsValidations.ValidateCpf(cpf))
                        context.AddFailure("CPF inválido");
                });

        }
    }
}

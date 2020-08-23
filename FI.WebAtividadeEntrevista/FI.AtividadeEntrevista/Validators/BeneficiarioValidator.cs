using FI.AtividadeEntrevista.DML;
using FI.WebAtividadeEntrevista.CrossCutting.Validators;
using FluentValidation;

namespace FI.AtividadeEntrevista.Validators
{
    public class BeneficiarioValidator : AbstractValidator<Beneficiario>
    {
        public BeneficiarioValidator()
        {
            RuleFor(b => b.Nome)
                .NotNullWithMessage()
                .MinimumLength(3)
                .MaximumLength(30);

            RuleFor(b => b.Cpf)
                .NotNullWithMessage()
                .Custom((cpf, context) => {
                    if (!BrazilianDocumentsValidations.ValidateCpf(cpf))
                        context.AddFailure("CPF inválido");
                } );
            
        }
    }
}

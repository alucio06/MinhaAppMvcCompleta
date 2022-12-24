using DevIO.Business.Models;
using FluentValidation;
using FluentValidation.Results;

namespace DevIO.Business.Services
{
    public abstract class BaseService
    {
        protected void Notificar(ValidationResult validationResult)
        {
            validationResult.Errors.ForEach(e => Notificar(e.ErrorMessage));
        }

        protected void Notificar(string mensagem)
        {
            // Propagar esse erro até a camada de apresentação
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }

    }
}

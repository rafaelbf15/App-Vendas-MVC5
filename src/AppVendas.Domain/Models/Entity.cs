using DomainValidation.Validation;
using System;

namespace AppVendas.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public void AdicionarErroValidacao(string erro, string mensagem)
        {
            ValidationResult.Add(new ValidationError(mensagem));
        }
        
        public void AdicionarErrosValidacao(ValidationResult validationResult)
        {
            ValidationResult.Add(validationResult);
        }

        public void ZerarListaErros()
        {
            ValidationResult = new ValidationResult();
        }

        public abstract bool EhValido();
    }
}

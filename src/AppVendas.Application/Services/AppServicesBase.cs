using AppVendas.Domain.Intefaces;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Application.Services
{
    public abstract class AppServicesBase
    {
        private readonly IUnitOfWork _uow;

        public AppServicesBase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void AdicionarErrosValidacao(ValidationResult validationResult, string erro)
        {
            validationResult.Add(new ValidationError(erro));
        }

        protected bool Commit()
        {
            return _uow.Commit();
        }
    }
}

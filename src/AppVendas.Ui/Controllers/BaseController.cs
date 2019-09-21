using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppVendas.Ui.Controllers
{
    public abstract class BaseController : Controller
    {
        protected void PopularModelStateComErros(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Erros)
            {
                ModelState.AddModelError(string.Empty, erro.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppVendas.Ui.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.AlertaErro = "Ocorreu um erro";
            ViewBag.MensagemErro = "Ocorreu um erro, tente novamente ou contato um administrador";

            return View("Error");
        }

        public ActionResult NotFound()
        {
            ViewBag.AlertaErro = "Não encontrado";
            ViewBag.MensagemErro = "Não existe uma página para a URL informada";

            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            ViewBag.AlertaErro = "Acesso negado!";
            ViewBag.MensagemErro = "Você não tem permissão para executar isso!";

            return View("Error");
        }

    }
}
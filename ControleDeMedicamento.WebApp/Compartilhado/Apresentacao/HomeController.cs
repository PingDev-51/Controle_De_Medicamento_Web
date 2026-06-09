using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamento.WebApp.Compartilhado.Apresentacao;

public class HomeController : Controller
{
    [HttpGet]

    public ActionResult Index()
    {
        return View();
    }
}
using System;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.Base.Apresentacao;

public class RequisicaoBaseController : Controller
{
    public ActionResult InicioRequisicao()
    {
        return View();
    }
}

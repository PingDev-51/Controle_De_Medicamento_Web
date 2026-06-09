using System;
using ControleDeMedicamento.WebApp.ModuloFornecedores.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamento.WebApp.ModuloFornecedores.Apresentacao;

public class FornecedoresController : Controller
{
    IRepositorioFornecedores repositorioFornecedores;

    public FornecedoresController(IRepositorioFornecedores repositorioFornecedores)
    {
        this.repositorioFornecedores = repositorioFornecedores;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Fornecedor> fornecedor = repositorioFornecedores.SelecionarTodos();

        return View(fornecedor);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }


    [HttpPost]
    public ActionResult Cadastrar(CadastrarFornecedoresViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        Fornecedor novoFornecedor = new Fornecedor(
            cadastrarVm.Nome,
            cadastrarVm.Telefone,
            cadastrarVm.Cnpj
        );

        repositorioFornecedores.Cadastrar(novoFornecedor);

        return RedirectToAction(nameof(Listar));
    }


}

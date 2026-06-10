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

        return View(Mapearfornecedores(fornecedor));
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

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Fornecedor? fornecedor = repositorioFornecedores.SelecionarPorId(id);

        if (fornecedor == null)
            return RedirectToAction(nameof(Listar));

        EditarFornecedoresViewModel editarVm = new EditarFornecedoresViewModel(
            id,
            fornecedor.Nome,
            fornecedor.Telefone,
            fornecedor.Cnpj
        );

        return View(editarVm);

    }

    [HttpPost]
    public ActionResult Editar(EditarFornecedoresViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        Fornecedor forncedorAtualizado = new Fornecedor(
            editarVm.Nome,
            editarVm.Telefone,
            editarVm.Cnpj
        );

        repositorioFornecedores.Editar(editarVm.Id, forncedorAtualizado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Fornecedor? fornecedor = repositorioFornecedores.SelecionarPorId(id);

        if (fornecedor == null)
            return RedirectToAction(nameof(Listar));

        ExcluirFornecedoresViewModel excluirVm = new ExcluirFornecedoresViewModel(
            id,
            fornecedor.Nome,
            fornecedor.Telefone,
            fornecedor.Cnpj
        );

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirFornecedoresViewModel excluirVm)
    {
        Fornecedor? fornecedor = repositorioFornecedores.SelecionarPorId(excluirVm.Id);

        if (fornecedor != null)
            repositorioFornecedores.Excluir(fornecedor);

        return RedirectToAction(nameof(Listar));
    }


    private List<ListarFornecedoresViewModel> Mapearfornecedores(List<Fornecedor> listaDeFornecedores)
    {
        List<ListarFornecedoresViewModel> listarVm = listaDeFornecedores.Select(f => new ListarFornecedoresViewModel(
            f.Id,
            f.Nome,
            f.Telefone,
            f.Cnpj
        )).ToList();

        return listarVm;
    }
}

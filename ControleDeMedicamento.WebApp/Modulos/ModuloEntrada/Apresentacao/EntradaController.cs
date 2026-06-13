using System;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Apresentacao;

public class EntradaController : Controller
{
    private readonly IRepositorioRequisicaoEntrada repositorioRequisicaoEntrada;
    private readonly IRepositorioFuncionario repositorioFuncionario;
    private readonly IRepositorioMedicamento repositorioMedicamento;

    public EntradaController(
        IRepositorioRequisicaoEntrada repositorioRequisicaoEntrada,
        IRepositorioFuncionario repositorioFuncionario,
        IRepositorioMedicamento repositorioMedicamento)
    {
        this.repositorioRequisicaoEntrada = repositorioRequisicaoEntrada;
        this.repositorioFuncionario = repositorioFuncionario;
        this.repositorioMedicamento = repositorioMedicamento;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<RequisicaoEntrada> requisicoes = repositorioRequisicaoEntrada.SelecionarRequisicoesEntrada();

        return View(MapearRequisicoes(requisicoes));
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        var CadastrarVm = new CadastrarRequisicaoEntrdaViewModel
        {
            FuncionarioId = string.Empty,
            MedicamentoId = string.Empty,
            Funcionarios = SelecionarFuncionario(),
            Medicamentos = SelecionarMedicamento(),
            Quantidade = 0
        };

        return View(CadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarRequisicaoEntrdaViewModel cadastrarVm)
    {
        Funcionario? selecionarFuncionario = repositorioFuncionario.SelecionarPorId(cadastrarVm.FuncionarioId);
        Medicamento? selecionarMedicamento = repositorioMedicamento.SelecionarPorId(cadastrarVm.MedicamentoId);

        if (selecionarFuncionario == null)
            ModelState.AddModelError(nameof(cadastrarVm.FuncionarioId), "Selecione um funcionario valido");

        if (selecionarMedicamento == null)
            ModelState.AddModelError(nameof(cadastrarVm.MedicamentoId), "Selecione um medicamento valido");

        RequisicaoEntrada nova = new(
            selecionarFuncionario!,
            selecionarMedicamento!,
            cadastrarVm.Quantidade
        );

        repositorioRequisicaoEntrada.Cadastrar(nova);

        return RedirectToAction(nameof(Listar));
    }


    private List<ListarRequisicaoEntradaViewModels> MapearRequisicoes(List<RequisicaoEntrada> requisicoesEntrada)
    {
        List<ListarRequisicaoEntradaViewModels> listarVm = requisicoesEntrada.Select(r => new ListarRequisicaoEntradaViewModels(
            r.Id,
            r.Funcionario.Nome,
            r.Medicamento.Nome,
            r.Quantidade
        )).ToList();

        return listarVm;
    }

    private List<OpcaoFuncionarioViewModel> SelecionarFuncionario()
    {
        return repositorioFuncionario.SelecionarTodos().Select(f => new OpcaoFuncionarioViewModel(f.Id, f.Nome)).ToList();
    }

    private List<OpcaoMedicamentoViewModel> SelecionarMedicamento()
    {
        return repositorioMedicamento.SelecionarTodos().Select(m => new OpcaoMedicamentoViewModel(m.Id, m.Nome)).ToList();
    }
}

using System;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Apresentacao;

public class RequisicaoEntradaController : Controller
{
    private readonly IRepositorioRequisicaoEntrada repositorioRequisicaoEntrada;
    private readonly IRepositorioFuncionario repositorioFuncionario;
    private readonly IRepositorioMedicamento repositorioMedicamento;

    public RequisicaoEntradaController(
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

    [HttpPost]
    public ActionResult Cadastrar()
    {
        CadastrarRequisicaoEntrdaViewModel cadasstrarVm = new CadastrarRequisicaoEntrdaViewModel(
           string.Empty,
           string.Empty,
           SelecionarFuncionario(),
           SelecionarMedicamento(),
           0
       );

        return View(cadasstrarVm);
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

        if (!ModelState.IsValid)
            return View(cadastrarVm with
            {
                Funcionarios = SelecionarFuncionario(),
                Medicamentos = SelecionarMedicamento()
            });

        RequisicaoEntrada novarequisicao = new RequisicaoEntrada(
            selecionarFuncionario!,
            selecionarMedicamento!,
            cadastrarVm.quantidade
        );

        repositorioRequisicaoEntrada.Cadastrar(novarequisicao);

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

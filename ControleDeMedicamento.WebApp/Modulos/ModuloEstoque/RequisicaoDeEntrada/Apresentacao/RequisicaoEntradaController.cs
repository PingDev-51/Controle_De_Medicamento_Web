using System;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Apresentacao;

public class RequisicaoEntradaController : Controller
{
    private readonly IRepositorioRequisicaoEntrada repositorioRequisicaoEntrada;

    public RequisicaoEntradaController(IRepositorioRequisicaoEntrada repositorioRequisicaoEntrada)
    {
        this.repositorioRequisicaoEntrada = repositorioRequisicaoEntrada;
    }

    public ActionResult Listar()
    {
        List<RequisicaoEntrada> requisicoes = repositorioRequisicaoEntrada.SelecionarRequisicoesEntrada();

        return View();// iniciar a View listar da forma padrao
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


}

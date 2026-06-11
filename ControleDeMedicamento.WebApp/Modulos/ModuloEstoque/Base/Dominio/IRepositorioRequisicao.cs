using System;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Dominio;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.Base.Dominio;

public interface IRepositorioRequisicao
{
    void Cadastrar(RequisicaoBase requisicao);
    List<RequisicaoEntrada> SelecionarRequisicoesEntrada();
    // List<RequisicaoSaida> SelecionarRequisicoesSaida();
}


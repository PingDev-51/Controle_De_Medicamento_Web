using System;
using ControleDeMedicamento.WebApp.Arquivos.Infra.Arquivos;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.Base.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.Base.Infra;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Dominio;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Infra;

public class RepositorioRequisicaoEntradaEmArquivo : RepositorioRequisicaoEmArquivo, IRepositorioRequisicaoEntrada
{
    public RepositorioRequisicaoEntradaEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }
}
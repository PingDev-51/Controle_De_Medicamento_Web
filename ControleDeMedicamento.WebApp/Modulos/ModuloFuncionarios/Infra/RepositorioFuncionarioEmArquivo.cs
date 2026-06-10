using System;
using ControleDeMedicamento.WebApp.Arquivos.Infra.Arquivos;
using ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Dominio;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Infra;

public class RepositorioFuncionarioEmArquivo  : RepositorioBaseEmArquivo<Funcionario>, IRepositorioFuncionario
{
    public RepositorioFuncionarioEmArquivo(ContextoJson contexto) : base(contexto) { }

    protected override List<Funcionario> CarregarRegistros()
    {
        return contexto.Funcionarios;
    }
}

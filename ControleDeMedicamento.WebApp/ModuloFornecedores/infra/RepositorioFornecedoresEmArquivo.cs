using System;
using ControleDeMedicamento.WebApp.Arquivos.Infra.Arquivos;
using ControleDeMedicamento.WebApp.ModuloFornecedores.Dominio;

namespace ControleDeMedicamento.WebApp.ModuloFornecedores.infra;

public class RepositorioFornecedoresEmArquivo : RepositorioBaseEmArquivo<Fornecedor>, IRepositorioFornecedores
{
    public RepositorioFornecedoresEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Fornecedor> CarregarRegistros()
    {
        return contexto.Fornecedor;
    }
}

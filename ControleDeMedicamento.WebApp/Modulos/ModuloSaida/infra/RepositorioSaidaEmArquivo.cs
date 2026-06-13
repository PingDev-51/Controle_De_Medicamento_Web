using ControleDeMedicamento.WebApp.Arquivos.Infra.Arquivos;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Dominio;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Infra;

public class RepositorioSaidaEmArquivo : RepositorioBaseEmArquivo<Saida>, IRepositorioSaida
{
    public RepositorioSaidaEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Saida> CarregarRegistros()
    {
        return contexto.Saidas;
    }
}
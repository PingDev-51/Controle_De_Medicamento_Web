using ControleDeMedicamento.WebApp.Arquivos.Infra.Arquivos;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Dominio;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Infra;
using ControleDeMedicamento.WebApp.ModuloFornecedores.Dominio;
using ControleDeMedicamento.WebApp.ModuloFornecedores.infra;
using ControleDeMedicamento.WebApp.ModuloPacientes.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Infra;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Infra;
using ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Infra;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloPaciente.Infra;

public static class InjecaoDepencencia
{
    public static void AdicionarCamadaInfraestrutura(this IServiceCollection services)
    {
        services.AddScoped(provider =>
    {
        ContextoJson contextoJson = new ContextoJson();

        contextoJson.Carregar();

        return contextoJson;
    });
        services.AddScoped<IRepositorioFornecedores, RepositorioFornecedoresEmArquivo>();
        services.AddScoped<IRepositorioPaciente, RepositorioPacienteEmArquivo>();
        services.AddScoped<IRepositorioFuncionario, RepositorioFuncionarioEmArquivo>();
        services.AddScoped<IRepositorioMedicamento, RepositorioMedicamentoEmArquivo>();
        services.AddScoped<IRepositorioRequisicaoEntrada, RepositorioRequisicaoEntradaEmArquivo>();
        services.AddScoped<IRepositorioSaida, RepositorioSaidaEmArquivo>();
    }
}
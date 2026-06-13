using ControleDeMedicamento.WebApp.ModuloFornecedores.Aplicacao;
using ControleDeMedicamento.WebApp.ModuloPacientes.Aplicacao;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Apresentacao;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Aplicacao;
using ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Aplicacao;
using ControleDeMedicamento.WebApp.Modulos.ModuloMedicamentos.Aplicacao;

namespace ControleDeMedicamento.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependecencia
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ServicoFornecedor>();
        services.AddScoped<ServicoPaciente>();
        services.AddScoped<ServicoMedicamentos>();
        services.AddScoped<ServicoFuncionario>();
        services.AddScoped<ServicoSaida>();
    }
}
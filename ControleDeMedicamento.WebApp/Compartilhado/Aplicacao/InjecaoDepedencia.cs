using ControleDeMedicamento.WebApp.ModuloPacientes.Aplicacao;
using ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Aplicacao;

namespace ControleDeMedicamento.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependecencia
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ServicoPaciente>();
        services.AddScoped<ServicoFuncionario>();

    }
}
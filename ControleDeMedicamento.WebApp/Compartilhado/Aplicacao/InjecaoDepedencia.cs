using ControleDeMedicamento.WebApp.ModuloPacientes.Aplicacao;

namespace ControleDeMedicamento.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependecencia
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ServicoPaciente>();
    }
}
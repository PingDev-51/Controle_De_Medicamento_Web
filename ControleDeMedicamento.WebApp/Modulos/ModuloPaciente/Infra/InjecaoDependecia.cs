using ControleDeMedicamento.WebApp.Arquivos.Infra.Arquivos;
using ControleDeMedicamento.WebApp.ModuloPacientes.Dominio;
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

        services.AddScoped<IRepositorioPaciente, RepositorioPacienteEmArquivo>();
        services.AddScoped<IRepositorioFuncionario, RepositorioFuncionarioEmArquivo>();
        
    }
}
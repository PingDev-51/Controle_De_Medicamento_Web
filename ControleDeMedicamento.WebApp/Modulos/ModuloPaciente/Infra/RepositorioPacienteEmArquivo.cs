using ControleDeMedicamento.WebApp.Arquivos.Infra.Arquivos;
using ControleDeMedicamento.WebApp.ConsoleApp.ModuloPacientes;
using ControleDeMedicamento.WebApp.ModuloPacientes.Dominio;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloPaciente.Infra;

public class RepositorioPacienteEmArquivo : RepositorioBaseEmArquivo<Paciente>, IRepositorioPaciente
{
    public RepositorioPacienteEmArquivo(ContextoJson contexto) : base(contexto) { }

    protected override List<Paciente> CarregarRegistros()
    {
        return contexto.Pacientes;
    }
}

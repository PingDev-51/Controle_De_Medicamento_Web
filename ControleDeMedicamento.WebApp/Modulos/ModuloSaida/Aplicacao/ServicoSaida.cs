using ControleDeMedicamento.WebApp.ConsoleApp.ModuloPacientes;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Dominio;
using ControleDeMedicamento.WebApp.ModuloPacientes.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Dominio;
using FluentResults;


namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Aplicacao;

public class ServicoSaida
{
    private readonly IRepositorioSaida repositorioSaida;
    private readonly IRepositorioPaciente repositorioPaciente;
    private readonly IRepositorioMedicamento repositorioMedicamento;

    public ServicoSaida(
        IRepositorioSaida repositorioSaida,
        IRepositorioPaciente repositorioPaciente,
        IRepositorioMedicamento repositorioMedicamento

    )
    {
        this.repositorioSaida = repositorioSaida;
        this.repositorioPaciente = repositorioPaciente;
        this.repositorioMedicamento = repositorioMedicamento;
    }


    public Result Cadastrar(CadastrarSaidaDto dto)
    {
        Paciente? pacienteSelecionada = repositorioPaciente.SelecionarPorId(dto.PacienteId);
        Medicamento? medicamentoSelecionado = repositorioMedicamento.SelecionarPorId(dto.MedicamentoId);

        Saida novaSaida = new Saida(
            pacienteSelecionada,
            medicamentoSelecionado,
            dto.QuantidadeSaida
        );

        repositorioSaida.Cadastrar(novaSaida);

        return Result.Ok();
    }

    public List<ListarSaidaDto> SelecionarTodos()
    {
        return repositorioSaida
            .SelecionarTodos()
            .Select(s => new ListarSaidaDto(
                s.Id,
                s.Data,
                s.Paciente.Nome,
                s.Medicamentos.Nome,
                s.QuantidadeSaida
            ))
            .ToList();
    }
    private static Result Falha(string campo, string mensagem)
    {
        IError erro = new Error(mensagem).WithMetadata("Campo", campo);

        return Result.Fail(erro);
    }

    public List<Paciente> SelecionarPacientes()
    {
        return repositorioPaciente.SelecionarTodos();
    }

    public List<Medicamento> SelecionarMedicamentos()
    {
        return repositorioMedicamento.SelecionarTodos();
    }
}
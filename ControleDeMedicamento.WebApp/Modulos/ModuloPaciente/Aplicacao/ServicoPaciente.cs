using System.Runtime.Intrinsics.X86;
using ControleDeMedicamento.WebApp.ConsoleApp.ModuloPacientes;
using ControleDeMedicamento.WebApp.ModuloPacientes.Dominio;
using FluentResults;

namespace ControleDeMedicamento.WebApp.ModuloPacientes.Aplicacao;

public class ServicoPaciente
{
    private readonly IRepositorioPaciente repositorioPaciente;

    public ServicoPaciente(
        IRepositorioPaciente repositorioPaciente
    )
    {
        this.repositorioPaciente = repositorioPaciente;
    }

    public Result Cadastrar(CadastrarPacienteDto dto)
    {
        if (ExistePacienteComSus(dto.CartaoSus))
            return Falha("Cartão do Sus", "Já existe um com paciente com esse cartão do sus.");

        Paciente novoPaciente = new Paciente(
            dto.Nome,
            dto.Telefone,
            dto.CartaoSus,
            dto.Cpf
        );

        repositorioPaciente.Cadastrar(novoPaciente);

        return Result.Ok();
    }

    public Result Editar(EditarPacienteDto dto)
    {
        if (ExistePacienteComSus(dto.CartaoSus, dto.Id))
            return Falha("Cartão do Sus", "Já existe um paciente com esse cartão do sus.");

        Paciente pacienteAtualizado = new Paciente(
            dto.Nome,
            dto.Telefone,
            dto.CartaoSus,
            dto.Cpf
        );

        bool conseguiuEditar = repositorioPaciente.Editar(
            dto.Id,
            pacienteAtualizado
        );

        if (!conseguiuEditar)
            return Result.Fail("Paciente não encontrado.");

        return Result.Ok();
    }
    
    public Result Excluir(string id)
    {
        Paciente? paciente = repositorioPaciente.SelecionarPorId(id);

        if (paciente == null)
            return Result.Fail("Paciente não encontrado.");

        repositorioPaciente.Excluir(paciente);

        return Result.Ok();
    }

    public List<ListarPacienteDto> SelecionarTodos()
    {
        List<Paciente> pacientes = repositorioPaciente.SelecionarTodos();

        return pacientes
            .Select(p => new ListarPacienteDto(p.Id, p.Nome, p.Telefone, p.CartaoSus, p.Cpf))
            .ToList();
    }

    public Result<DetalhesPacienteDto> SelecionarPorId(string id)
    {
        Paciente? paciente = repositorioPaciente.SelecionarPorId(id);

        if (paciente == null)
            return Result.Fail("paciente não encontrada.");

        return Result.Ok(new DetalhesPacienteDto(paciente.Id, paciente.Nome, paciente.Telefone, paciente.CartaoSus, paciente.Cpf));
    }

    private bool ExistePacienteComSus(string cartaoSus, string? idIgnorado = null)
    {
        List<Paciente> pacientes = repositorioPaciente.SelecionarTodos();

        foreach (Paciente p in pacientes)
        {
            if (p.Id != idIgnorado && string.Equals(p.CartaoSus, cartaoSus, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }

    private static Result Falha(string campo, string mensagem)
    {
        IError erro = new Error(mensagem).WithMetadata("Campo", campo);

        return Result.Fail(erro);
    }
}
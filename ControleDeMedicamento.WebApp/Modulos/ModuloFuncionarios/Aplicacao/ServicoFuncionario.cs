using System;
using ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Dominio;
using FluentResults;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Aplicacao;

public class ServicoFuncionario
{

    private readonly IRepositorioFuncionario repositorioFuncionario;

    public ServicoFuncionario(
        IRepositorioFuncionario repositorioFuncionario
    )
    {
        this.repositorioFuncionario = repositorioFuncionario;
    }

    public Result Cadastrar(CadastrarFuncionarioDto dto)
    {
        if (ExisteFuncionarioComSus(dto.Cpf))
            return Falha("CPF", "Já existe um com Funcionario com esse CPF.");

        Funcionario novoFuncionario = new Funcionario(
            dto.Nome,
            dto.Telefone,
            dto.Cpf
        );

        repositorioFuncionario.Cadastrar(novoFuncionario);

        return Result.Ok();
    }

    public Result Editar(EditarFuncionarioDto dto)
    {
        if (ExisteFuncionarioComSus(dto.Cpf, dto.Id))
            return Falha("CPF", "Já existe um Funcionario com esse CPF.");

        Funcionario FuncionarioAtualizado = new Funcionario(
            dto.Nome,
            dto.Telefone,
            dto.Cpf
        );

        bool conseguiuEditar = repositorioFuncionario.Editar(
            dto.Id,
            FuncionarioAtualizado
        );

        if (!conseguiuEditar)
            return Result.Fail("Funcionario não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(string id)
    {
        Funcionario? Funcionario = repositorioFuncionario.SelecionarPorId(id);

        if (Funcionario == null)
            return Result.Fail("Funcionario não encontrado.");

        repositorioFuncionario.Excluir(Funcionario);

        return Result.Ok();
    }

    public List<ListarFuncionarioDto> SelecionarTodos()
    {
        List<Funcionario> Funcionarios = repositorioFuncionario.SelecionarTodos();

        return Funcionarios
            .Select(p => new ListarFuncionarioDto(p.Id, p.Nome, p.Telefone, p.Cpf))
            .ToList();
    }

    public Result<DetalhesFuncionarioDto> SelecionarPorId(string id)
    {
        Funcionario? Funcionario = repositorioFuncionario.SelecionarPorId(id);

        if (Funcionario == null)
            return Result.Fail("Funcionario não encontrada.");

        return Result.Ok(new DetalhesFuncionarioDto(Funcionario.Id, Funcionario.Nome, Funcionario.Telefone, Funcionario.Cpf));
    }

    private bool ExisteFuncionarioComSus(string Cpf, string? idIgnorado = null)
    {
        List<Funcionario> Funcionarios = repositorioFuncionario.SelecionarTodos();

        foreach (Funcionario p in Funcionarios)
        {
            if (p.Id != idIgnorado && string.Equals(p.Cpf, Cpf, StringComparison.OrdinalIgnoreCase))
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
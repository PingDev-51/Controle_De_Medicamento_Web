using ControleDeMedicamento.WebApp.ModuloFornecedores.Dominio;
using FluentResults;


namespace ControleDeMedicamento.WebApp.ModuloFornecedores.Aplicacao;

public class ServicoFornecedor
{
    private readonly IRepositorioFornecedores repositorioFornecedor;

    public ServicoFornecedor(
        IRepositorioFornecedores repositorioFornecedor
    )
    {
        this.repositorioFornecedor = repositorioFornecedor;
    }

    public Result Cadastrar(CadastrarFornecedorDto dto)
    {
        if (ExisteFornecedorComCnpj(dto.Cnpj))
           return Falha("CNPJ", "Já existe um fornecedor cadastrado com esse CNPJ.");

        Fornecedor novoFornecedor = new Fornecedor(
            dto.Nome,
            dto.Telefone,
            dto.Cnpj
        );

        repositorioFornecedor.Cadastrar(novoFornecedor);

        return Result.Ok();
    }

    public Result Editar(EditarFornecedorDto dto)
    {
        if (ExisteFornecedorComCnpj(dto.Cnpj, dto.Id))
            return Falha("CNPJ", "Já existe um Fornecedor com esse CNPJ.");

        Fornecedor FornecedorAtualizado = new Fornecedor(
            dto.Nome,
            dto.Telefone,
            dto.Cnpj
        );

        bool conseguiuEditar = repositorioFornecedor.Editar(
            dto.Id,
            FornecedorAtualizado
        );

        if (!conseguiuEditar)
            return Result.Fail("Fornecedor não encontrado.");

        return Result.Ok();
    }
    
    public Result Excluir(string id)
    {
        Fornecedor? Fornecedor = repositorioFornecedor.SelecionarPorId(id);

        if (Fornecedor == null)
            return Result.Fail("Fornecedor não encontrado.");

        repositorioFornecedor.Excluir(Fornecedor);

        return Result.Ok();
    }

    public List<ListarFornecedorDto> SelecionarTodos()
    {
        List<Fornecedor> Fornecedors = repositorioFornecedor.SelecionarTodos();

        return Fornecedors
            .Select(p => new ListarFornecedorDto(p.Id, p.Nome, p.Telefone, p.Cnpj))
            .ToList();
    }

    public Result<DetalhesFornecedorDto> SelecionarPorId(string id)
    {
        Fornecedor? Fornecedor = repositorioFornecedor.SelecionarPorId(id);

        if (Fornecedor == null)
            return Result.Fail("Fornecedor não encontrada.");

        return Result.Ok(new DetalhesFornecedorDto(Fornecedor.Id, Fornecedor.Nome, Fornecedor.Telefone, Fornecedor.Cnpj));
    }

    private bool ExisteFornecedorComCnpj(string cnpj, string? idIgnorado = null)
    {
        List<Fornecedor> Fornecedors = repositorioFornecedor.SelecionarTodos();

        foreach (Fornecedor p in Fornecedors)
        {
            if (p.Id != idIgnorado && string.Equals(p.Cnpj, cnpj, StringComparison.OrdinalIgnoreCase))
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
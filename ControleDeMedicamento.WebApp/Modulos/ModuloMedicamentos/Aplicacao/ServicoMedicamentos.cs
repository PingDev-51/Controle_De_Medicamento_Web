using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Dominio;
using ControleDeMedicamento.WebApp.ModuloFornecedores.Dominio;
using FluentResults;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloMedicamentos.Aplicacao;

public class ServicoMedicamentos
{

    private readonly IRepositorioMedicamento repositorioMedicamento;
    private readonly IRepositorioFornecedores repositorioFornecedor;

    public ServicoMedicamentos(
        IRepositorioMedicamento repositorioMedicamento,
        IRepositorioFornecedores repositorioFornecedor

    )
    {
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioFornecedor = repositorioFornecedor;
    }

    public Result Cadastrar(CadastrarMedicamentoDto dto)
    {
        Fornecedor? FornecedorSelecionada = repositorioFornecedor.SelecionarPorId(dto.FornecedorId);

        if (FornecedorSelecionada == null)
            return Falha(nameof(dto.FornecedorId), "Selecione uma Fornecedor válida.");

        Medicamento novoMedicamento = new Medicamento(
            dto.Nome,
            dto.Descricao,
            FornecedorSelecionada
        );

        Result resultadoValidacao = ValidarEntidade(novoMedicamento);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioMedicamento.Cadastrar(novoMedicamento);

        return Result.Ok();
    }

    public Result Editar(EditarMedicamentoDto dto)
    {
        Medicamento? Medicamento = repositorioMedicamento.SelecionarPorId(dto.Id);

        if (Medicamento == null)
            return Result.Fail("Medicamento não encontrado.");

        Fornecedor? FornecedorSelecionada = repositorioFornecedor.SelecionarPorId(dto.FornecedorId);

        if (FornecedorSelecionada == null)
            return Falha(nameof(dto.FornecedorId), "Selecione uma Fornecedor válida.");

        Medicamento MedicamentoAtualizado = new Medicamento(
            dto.Nome,
            dto.Descricao,
            FornecedorSelecionada
        );

        Result resultadoValidacao = ValidarEntidade(MedicamentoAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioMedicamento.Editar(dto.Id, MedicamentoAtualizado);

        return Result.Ok();
    }

    public Result Excluir(string id)
    {
        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(id);

        if (medicamento == null)
            return Result.Fail("medicamento não encontrado.");

        repositorioMedicamento.Excluir(medicamento);

        return Result.Ok();
    }

    public List<ListarMedicamentoDto> SelecionarTodos()
    {
        return repositorioMedicamento
            .SelecionarTodos()
            .Select(p => new ListarMedicamentoDto(
                p.Id,
                p.Nome,
                p.Descricao,
                p.Fornecedor.Nome
            ))
            .ToList();
    }

    public Result<DetalhesMedicamentoDto> SelecionarPorId(string id)
    {
        Medicamento? Medicamento = repositorioMedicamento.SelecionarPorId(id);

        if (Medicamento == null)
            return Result.Fail("Medicamento não encontrado.");

        return Result.Ok(new DetalhesMedicamentoDto(
            Medicamento.Id,
            Medicamento.Nome,
            Medicamento.Fornecedor.Id,
            Medicamento.Fornecedor.Nome
        ));
    }

    public List<OpcaoFornecedoresDto> SelecionarFornecedores()
    {
        return repositorioFornecedor
            .SelecionarTodos()
            .Select(f => new OpcaoFornecedoresDto(f.Id, f.Nome))
            .ToList();
    }

    private static Result ValidarEntidade(Medicamento Medicamento)
    {
        List<string> erros = Medicamento.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(new Error(erros.First()).WithMetadata("Campo", string.Empty));
    }

    private static Result Falha(string campo, string mensagem)
    {
        return Result.Fail(new Error(mensagem).WithMetadata("Campo", campo));
    }
}
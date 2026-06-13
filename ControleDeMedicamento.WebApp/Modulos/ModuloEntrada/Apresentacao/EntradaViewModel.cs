namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Apresentacao;

public record ListarRequisicaoEntradaViewModels(
    string Id,
    string Funcionario,
    string Medicamento,
    uint Quantidade
);

public class CadastrarRequisicaoEntrdaViewModel
{
    public string FuncionarioId { get; set; } = string.Empty;
    public string MedicamentoId { get; set; } = string.Empty;

    public List<OpcaoFuncionarioViewModel> Funcionarios { get; set; } = new();
    public List<OpcaoMedicamentoViewModel> Medicamentos { get; set; } = new();

    public uint Quantidade { get; set; }
}

public record OpcaoFuncionarioViewModel(
    string Id,
    string Nome
);

public record OpcaoMedicamentoViewModel(
    string Id,
    string Nome
);



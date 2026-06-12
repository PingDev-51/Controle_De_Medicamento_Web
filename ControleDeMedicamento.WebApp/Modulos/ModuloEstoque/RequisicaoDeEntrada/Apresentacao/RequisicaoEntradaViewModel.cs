namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Apresentacao;

public record ListarRequisicaoEntradaViewModels(
    string Id,
    string Funcionario,
    string Medicamento,
    uint quantidade
);

public record CadastrarRequisicaoEntrdaViewModel(
    string Funcionario,
    string Medicamento,
    uint quantidade
);

public record OpcaoFuncionarioViewModel(
    string Id,
    string Nome
);

public record OpcaoMedicamentoViewModel(
    string Id,
    string Nome
);



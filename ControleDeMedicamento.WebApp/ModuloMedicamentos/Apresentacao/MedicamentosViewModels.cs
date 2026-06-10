namespace ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Apresentacao;

public record ListarMedicamentosViewModels(
    string Id,
    string Nome,
    string Descricao,
    string Fornecedor
);

public record CadastrarMedicamentosViewModels(
    string Nome,
    string Descricao,
    string Fornecedor
);

public record OpcaoFornecedorViewModel(
    string Id,
    string Nome
);

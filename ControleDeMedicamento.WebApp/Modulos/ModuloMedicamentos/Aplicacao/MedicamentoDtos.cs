namespace ControleDeMedicamento.WebApp.Modulos.ModuloMedicamentos.Aplicacao;


public record OpcaoFornecedoresDto(
    string Id,
    string Nome
);

public record ListarMedicamentoDto(
    string Id,
    string Nome,
    string Descricao,
    string Fornecedor
);

public record CadastrarMedicamentoDto(
    string Nome,
    string Descricao,
    string FornecedorId,
    string FornecedorNome
);

public record EditarMedicamentoDto(
    string Id,
    string Nome,
    string Descricao,
    string FornecedorId,
    string FornecedorNome
);

public record DetalhesMedicamentoDto(
    string Nome,
    string Descricao,
    string FornecedorId,
    string FornecedorNome
);
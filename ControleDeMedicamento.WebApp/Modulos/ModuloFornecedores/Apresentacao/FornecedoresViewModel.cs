using System;

namespace ControleDeMedicamento.WebApp.ModuloFornecedores.Apresentacao;

public record ListarFornecedoresViewModel(
    string Id,
    string Nome,
    string Telefone,
    string Cnpj
);

public record CadastrarFornecedoresViewModel(
    string Nome,
    string Telefone,
    string Cnpj
);

public record EditarFornecedoresViewModel(
    string Id,
    string Nome,
    string Telefone,
    string Cnpj
);

public record ExcluirFornecedoresViewModel(
    string Id,
    string Nome,
    string Telefone,
    string Cnpj
);
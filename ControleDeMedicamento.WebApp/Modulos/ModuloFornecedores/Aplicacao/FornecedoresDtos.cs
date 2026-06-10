namespace ControleDeMedicamento.WebApp.ModuloFornecedores.Aplicacao;

public record ListarFornecedorDto(
    string Id,
    string Nome,
    string Telefone,
    string Cnpj
);

public record CadastrarFornecedorDto(
    string Nome,
    string Telefone,
    string Cnpj
);

public record EditarFornecedorDto(
    string Id,
    string Nome,
    string Telefone,
    string Cnpj
);

public record DetalhesFornecedorDto(
    string Id,
    string Nome,
    string Telefone,
    string Cnpj
);
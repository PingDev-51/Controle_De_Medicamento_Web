using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamento.WebApp.ModuloFornecedores.Apresentacao;

public record ListarFornecedoresViewModel(
    string Id,
    string Nome,
    string Telefone,
    string Cnpj
);

public record CadastrarFornecedoresViewModel(
   [Required(ErrorMessage = "O campo Nome é obrigatorio")]
   [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Nome deve conter entre 3 a 100 caracteres")]
    string Nome,

    [Required(ErrorMessage = "O campo Telefone é obrigatorio")]
    [StringLength(11, ErrorMessage = "O campo Telefone deve conter 11 caracteres")]
    string Telefone,

    [Required(ErrorMessage = "O campo CNPJ é obrigatorio")]
    [StringLength(14, ErrorMessage = "O campo CNPJ deve conter 14 caracteres")]
    string Cnpj
);

public record EditarFornecedoresViewModel(
    string Id,

    [Required(ErrorMessage = "O campo Nome é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Nome deve conter entre 3 a 100 caracteres")]
    string Nome,

    [Required(ErrorMessage = "O campo Telefone é obrigatorio")]
    [StringLength(11, ErrorMessage = "O campo Telefone deve conter 11 caracteres")]
    string Telefone,

    [Required(ErrorMessage = "O campo CNPJ é obrigatorio")]
    [StringLength(14, ErrorMessage = "O campo CNPJ deve conter 14 caracteres")]
    string Cnpj
);

public record ExcluirFornecedoresViewModel(
    string Id,
    string Nome,
    string Telefone,
    string Cnpj
);
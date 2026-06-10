using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Apresentacao;
public record ListarFuncionarioViewModel(
    string Id,
    string Nome,
    string Telefone,
    string Cpf
);

public record CadastrarFuncionarioViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter no máximo 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"Cpf\" deve ser preenchido.")]
    [StringLength(12, ErrorMessage = "O campo \"Cpf\" deve conter no máximo 12 caracteres.")]
    string Cpf
);

public record EditarFuncionarioViewModel(
    string Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter no máximo 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"Cpf\" deve ser preenchido.")]
    [StringLength(12, ErrorMessage = "O campo \"Cpf\" deve conter no máximo 12 caracteres.")]
    string Cpf
);

public record ExcluirFuncionarioViewModel(
    string Id,
    string Nome,
    string Telefone,
    string Cpf
);
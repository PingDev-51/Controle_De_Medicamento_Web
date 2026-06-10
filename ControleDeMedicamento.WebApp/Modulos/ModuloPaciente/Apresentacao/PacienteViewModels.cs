using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamento.WebApp.ModuloPacientes.Apresentacao;

public record ListarPacienteViewModel(
    string Id,
    string Nome,
    string Telefone,
    string CartaoSus,
    string Cpf
);

public record CadastrarPacienteViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter no máximo 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"CartaoSus\" deve ser preenchido.")]
    [StringLength(16, ErrorMessage = "O campo \"CartaoSus\" deve conter no máximo 15 caracteres.")]
    string CartaoSus,

    [Required(ErrorMessage = "O campo \"Cpf\" deve ser preenchido.")]
    [StringLength(12, ErrorMessage = "O campo \"Cpf\" deve conter no máximo 12 caracteres.")]
    string Cpf
);

public record EditarPacienteViewModel(
    string Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter no máximo 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"CartaoSus\" deve ser preenchido.")]
    [StringLength(16, ErrorMessage = "O campo \"CartaoSus\" deve conter no máximo 15 caracteres.")]
    string CartaoSus,

    [Required(ErrorMessage = "O campo \"Cpf\" deve ser preenchido.")]
    [StringLength(12, ErrorMessage = "O campo \"Cpf\" deve conter no máximo 12 caracteres.")]
    string Cpf
);

public record ExcluirPacienteViewModel(
    string Id,
    string Nome,
    string Telefone,
    string CartaoSus,
    string Cpf
);

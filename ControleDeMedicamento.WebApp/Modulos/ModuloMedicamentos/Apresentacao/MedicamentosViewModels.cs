using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Apresentacao;

public record ListarMedicamentosViewModel(
    string Id,
    string Nome,
    string Descricao,
    string Fornecedor
);

public record CadastrarMedicamentosViewModel(
    [Required(ErrorMessage = "O campo Nome é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Nome deve conter entre 3 a 100 caracteres")]
    string Nome,

    [Required(ErrorMessage = "O campo Descrição é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Descrição deve conter entre 5 a 255 caracteres")]
    string Descricao,

    string FornecedorId,

    [ValidateNever]
    List<OpcaoFornecedorViewModel> Fornecedores
);

public record EditarMedicamentosViewModel(
    string Id,

    [Required(ErrorMessage = "O campo Nome é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Nome deve conter entre 3 a 100 caracteres")]
    string Nome,

    [Required(ErrorMessage = "O campo Descrição é obrigatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Descrição deve conter entre 5 a 255 caracteres")]
    string Descricao,

    string FornecedorId,

    [ValidateNever]
    List<OpcaoFornecedorViewModel> Fornecedores
);

public record ExcluirMedicamentosViewModel(
    string Id,

    string Nome,

    string Descricao,

    [ValidateNever]
    List<OpcaoFornecedorViewModel> Fornecedores
);

public record OpcaoFornecedorViewModel(
    string Id,
    string Nome
);

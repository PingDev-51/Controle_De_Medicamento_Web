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

    string Nome,

    string Descricao,

    string FornecedorId,

    [ValidateNever]
    List<OpcaoFornecedorViewModel> Fornecedores
);

public record EditarMedicamentosViewModel(
    string Id,

    string Nome,

    string Descricao,

    string FornecedorId,

    [ValidateNever]
    List<OpcaoFornecedorViewModel> Fornecedores
);

public record OpcaoFornecedorViewModel(
    string Id,
    string Nome
);

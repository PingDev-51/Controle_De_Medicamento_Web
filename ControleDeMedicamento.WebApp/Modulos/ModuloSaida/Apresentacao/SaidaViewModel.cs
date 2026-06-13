using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Apresentacao;
public record OpcaoPacienteViewModel(
    string Id,
    string Nome
);

public record OpcaoMedicamentosViewModel(
    string Id,
    string Nome
);


public record ListarSaidaViewModel(
    string Id,
    DateTime Data,
    string Paciente,
    string Medicamento,
    int QuantidadeSaida
);

public record CadastrarSaidaViewModel(
    DateTime Data,
    string PacienteId,
    string MedicamentoId,
    int QuantidadeSaida,

    
    [ValidateNever]
    List<OpcaoPacienteViewModel> Pacientes,

    [ValidateNever]
    List<OpcaoMedicamentosViewModel> Medicametos

);


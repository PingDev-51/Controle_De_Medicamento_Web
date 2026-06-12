namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Aplicacao;
public record OpcaoPacienteDto(
    string Id,
    string Nome
);

public record OpcaoMedicametosDto(
    string Id,
    string Nome
);

public record ListarSaidaDto(
    string Id,
    DateTime Data,
    string Paciente,
    string Medicamento,
    int QuantidadeSaida
);

public record CadastrarSaidaDto(
    DateTime Data,
    string PacienteId,
    string PacienteNome,
    string MedicamentoId,
    string MedicamentoNome,
    int QuantidadeSaida
);

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

public record CadastrarSaidaDto
{
    public DateTime Data { get; set; }
    public string PacienteId { get; set; }
    public string PacienteNome { get; set; }
    public string MedicamentoId { get; set; }
    public string MedicamentoNome { get; set; }
    public int QuantidadeSaida { get; set; }
}

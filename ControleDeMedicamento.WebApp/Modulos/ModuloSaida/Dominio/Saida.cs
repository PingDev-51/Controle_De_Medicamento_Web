
using ControleDeMedicamento.WebApp.Compartilhado.Dominio.Base;
using ControleDeMedicamento.WebApp.ConsoleApp.ModuloPacientes;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Dominio;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Dominio;

public class Saida : EntidadeBase<Saida>
{
    public DateTime Data { get; set; } = DateTime.Now;
    public Paciente Paciente { get; set; } = null!;
    public Medicamento Medicamentos { get; set; } = null!;
    public int QuantidadeSaida { get; set; }

    public Saida()
    {
    }

    public Saida(Paciente paciente, Medicamento medicamentos, int quantidadeSaida)
    {
        Data = DateTime.Now;
        Paciente = paciente;
        Medicamentos = medicamentos;
        QuantidadeSaida = quantidadeSaida;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Paciente == null)
            erros.Add ("o campo Paciente deve ser preenchido;");

        if (Medicamentos == null)
            erros.Add ("O cmapo Medicamento deve ser preenchido;");

        return erros;
    }

    public override void AtualizarDados(Saida entidadeAtualizada)
    {
        throw new NotImplementedException();
    }
}
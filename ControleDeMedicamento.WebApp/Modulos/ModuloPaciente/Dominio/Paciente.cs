using System;
using ControleDeMedicamento.WebApp.Compartilhado.Dominio.Base;

namespace ControleDeMedicamento.WebApp.ConsoleApp.ModuloPacientes;

public class Paciente : EntidadeBase<Paciente>
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CartaoSus { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;

    public Paciente() // cosntrutor vasio para o Deserialize funcionar corretamente.
    {

    }

    public Paciente(string nome, string telefone, string cartaoSus, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        CartaoSus = cartaoSus;
        Cpf = cpf;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O Campo \"Nome\" deve conter no entre 3 e 100 caracteres.;");

        if (string.IsNullOrWhiteSpace(Telefone))
            erros.Add("O Campo \"Telefone\" é obrigatório.;");

        else if (Telefone.Length != 14 && Telefone.Length != 15)
            erros.Add("O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;");

        else if (Telefone[0] != '(' || Telefone[3] != ')' || Telefone[4] != ' ')
            erros.Add("O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;");

        else if (Telefone.Length == 14 && Telefone[9] != '-')
            erros.Add ("O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;");

        else if (Telefone.Length == 15 && Telefone[10] != '-')
            erros.Add("O Campo \"Telefone\" deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.;");

        if (CartaoSus.Length > 15)
            erros.Add("O Campo \"Cartão Do SUS\" deve conter 15 digitos;");

        if (Cpf.Length > 11)
            erros.Add("O Campo \"CPF\" deve conter 11 digitos;");

        return erros;
    }

    public override void AtualizarDados(Paciente entidadeAtualizada)
    {
        Paciente pacienteAtualizado = (Paciente)entidadeAtualizada;

        Nome = pacienteAtualizado.Nome;
        Telefone = pacienteAtualizado.Telefone;
        CartaoSus = pacienteAtualizado.CartaoSus;
        Cpf = pacienteAtualizado.Cpf;
    }
}
using ControleDeMedicamento.WebApp.Compartilhado.Dominio.Base;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Dominio;

public class Funcionario : EntidadeBase<Funcionario>
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;

    public Funcionario() // cosntrutor vasio para o Deserialize funcionar corretamente.
    {

    }

    public Funcionario(string nome, string telefone, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
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

        if (Cpf.Length > 11)
            erros.Add("O Campo \"CPF\" deve conter 11 digitos;");

        return erros;
    }

    public override void AtualizarDados(Funcionario entidadeAtualizada)
    {
        Funcionario FuncionarioAtualizado = (Funcionario)entidadeAtualizada;

        Nome = FuncionarioAtualizado.Nome;
        Telefone = FuncionarioAtualizado.Telefone;
        Cpf = FuncionarioAtualizado.Cpf;
    }
}
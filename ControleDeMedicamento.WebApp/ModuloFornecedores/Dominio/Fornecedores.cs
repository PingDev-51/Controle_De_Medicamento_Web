using System;
using ControleDeMedicamento.WebApp.Compartilhado.Dominio.Base;

namespace ControleDeMedicamento.WebApp.ModuloFornecedores.Dominio;

public class Fornecedor : EntidadeBase<Fornecedor>
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;

    public Fornecedor()
    {

    }

    public Fornecedor(string nome, string telefone, string cnpj)
    {
        Nome = nome;
        Telefone = telefone;
        Cnpj = cnpj;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo nome deve ser preenchido;");
        else if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo nome deve conter entre 3 a 100 caracteres;");

        if (string.IsNullOrWhiteSpace(Telefone))
            erros.Add("O Campo \"Telefone\" é obrigatório.;");
        else if (Telefone.Length != 14 && Telefone.Length != 15)
            erros.Add("O Campo \"Telefone\" deve estar no formato (##) ####-#### ou (##) #####-####.;");

        else if (Telefone[0] != '(' || Telefone[3] != ')' || Telefone[4] != ' ')
            erros.Add("O Campo \"Telefone\" deve estar no formato (##) ####-#### ou (##) #####-####.;");

        else if (Telefone.Length == 14 && Telefone[9] != '-')
            erros.Add("O Campo \"Telefone\" deve estar no formato (##) ####-#### ou (##) #####-####.;");

        else if (Telefone.Length == 15 && Telefone[10] != '-')
            erros.Add("O Campo \"Telefone\" deve estar no formato (##) ####-#### ou (##) #####-####.;");

        if (string.IsNullOrWhiteSpace(Cnpj))
            erros.Add("O campo CNPJ deve ser preenchido;");
        else if (Cnpj.Length < 14)
            erros.Add("O campo CNPJ deve conter 14 caracteres;");

        return erros;
    }

    public override void AtualizarDados(Fornecedor entidadeAtualizada)
    {
        Fornecedor fornecedorAtualizado = (Fornecedor)entidadeAtualizada;

        Nome = fornecedorAtualizado.Nome;
        Telefone = fornecedorAtualizado.Telefone;
        Cnpj = fornecedorAtualizado.Cnpj;
    }
}
using System.Text.Json;
using System.Text.Json.Serialization;
using ControleDeMedicamento.WebApp.ConsoleApp.ModuloPacientes;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Dominio;
using ControleDeMedicamento.WebApp.ModuloFornecedores.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.Base.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Dominio;

namespace ControleDeMedicamento.WebApp.Arquivos.Infra.Arquivos;

public sealed class ContextoJson
{
    public List<Fornecedor> Fornecedores { get; set; } = new();
    public List<Paciente> Pacientes { get; set; } = new();
    public List<Medicamento> Medicamentos { get; set; } = new();
    public List<Funcionario> Funcionarios { get; set; } = new();
    public List<RequisicaoBase> Requisicoes = new List<RequisicaoBase>();

    private readonly string caminhoArquivo;

    public ContextoJson()
    {
        string caminhoAppData = Environment
            .GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        string caminhoDiretorio = Path.Combine(caminhoAppData, "ControleDeMedicametosWeb");

        Directory.CreateDirectory(caminhoDiretorio);

        caminhoArquivo = Path.Combine(caminhoDiretorio, "dados.json");
    }

    public void Salvar()
    {
        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.WriteIndented = true;
        opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        string jsonString = JsonSerializer.Serialize(this, opcoesJson);

        File.WriteAllText(caminhoArquivo, jsonString);
    }

    public void Carregar()
    {
        if (!File.Exists(caminhoArquivo))
            return;

        string jsonString = File.ReadAllText(caminhoArquivo);

        JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
        opcoesJson.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoJson? contextoSalvo = JsonSerializer
            .Deserialize<ContextoJson>(jsonString, opcoesJson);

        if (contextoSalvo == null)
            return;

        //salvar os contextos aqui
        Fornecedores = contextoSalvo.Fornecedores;
        Pacientes = contextoSalvo.Pacientes;
        Medicamentos = contextoSalvo.Medicamentos;
        Funcionarios = contextoSalvo.Funcionarios;
        Requisicoes = contextoSalvo.Requisicoes;
    }
}
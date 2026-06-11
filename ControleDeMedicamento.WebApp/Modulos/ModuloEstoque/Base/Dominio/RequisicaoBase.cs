using System;
using System.Text.Json.Serialization;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeEntrada.Dominio;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.Base.Dominio;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$tipo")]
[JsonDerivedType(typeof(RequisicaoEntrada), "entrada")]
// [JsonDerivedType(typeof(RequisicaoSaida), "saida")] Pra nn dar par no commit eu comentei mas quando vc criar essa parte aqui so descomentar vai ter algumas partes do codigo assim
public abstract class RequisicaoBase
{
    public string Id { get; set; } = GeradorIds.GerarIdCurto();
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}

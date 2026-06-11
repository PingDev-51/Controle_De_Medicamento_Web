using System;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Dominio;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.Base.Dominio;

public class MedicamentoPrescrito
{
    public Medicamento Medicamento { get; set; } = null!;
    public uint Quantidade { get; set; } = 0;

    public MedicamentoPrescrito()
    {
    }

    public MedicamentoPrescrito(Medicamento medicamento, uint quantidade) : this()
    {
        Medicamento = medicamento;
        Quantidade = quantidade;
    }
}
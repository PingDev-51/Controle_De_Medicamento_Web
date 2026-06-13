using AutoMapper;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Apresentacao;

public class OpcaoMedicamentoProfile : Profile
{
    public OpcaoMedicamentoProfile()
    {
        CreateMap<Medicamento, OpcaoMedicamentosViewModel>();
    }
}
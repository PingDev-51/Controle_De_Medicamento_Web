using AutoMapper;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Apresentacao;
using ControleDeMedicamento.WebApp.Modulos.ModuloMedicamentos.Aplicacao;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloMedicamentos.Apresentacao;

public class MedicamentosProfile : Profile
{
    public MedicamentosProfile()
    {
        CreateMap<ListarMedicamentoDto, ListarMedicamentosViewModel>();
        CreateMap<CadastrarMedicamentosViewModel, CadastrarMedicamentoDto>();
        CreateMap<EditarMedicamentosViewModel, EditarMedicamentoDto>();
        CreateMap<DetalhesMedicamentoDto, EditarMedicamentosViewModel>();
    }
}
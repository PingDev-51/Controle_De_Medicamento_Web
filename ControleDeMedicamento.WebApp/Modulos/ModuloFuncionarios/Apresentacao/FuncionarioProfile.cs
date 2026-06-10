using AutoMapper;
using ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Aplicacao;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Apresentacao;

public class FuncionarioProfile : Profile
{
    public FuncionarioProfile()
    {
        CreateMap<ListarFuncionarioDto, ListarFuncionarioViewModel>();
        CreateMap<CadastrarFuncionarioViewModel, CadastrarFuncionarioDto>();
        CreateMap<EditarFuncionarioViewModel, EditarFuncionarioDto>();
        CreateMap<DetalhesFuncionarioDto, EditarFuncionarioViewModel>();
    }
}
using AutoMapper;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Aplicacao;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Apresentacao;

public class SaidaProfile : Profile
{
    public SaidaProfile()
    {
        CreateMap<ListarSaidaDto, ListarSaidaViewModel>();
        CreateMap<CadastrarSaidaViewModel, CadastrarSaidaDto>();
    }
}
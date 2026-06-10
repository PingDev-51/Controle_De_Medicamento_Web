using AutoMapper;
using ControleDeMedicamento.WebApp.ModuloFornecedores.Aplicacao;

namespace ControleDeMedicamento.WebApp.ModuloFornecedores.Apresentacao;

public class FornecedoresProfile : Profile
{
    public FornecedoresProfile()
    {
        CreateMap<ListarFornecedorDto, ListarFornecedoresViewModel>();
        CreateMap<CadastrarFornecedoresViewModel, CadastrarFornecedorDto>();
        CreateMap<EditarFornecedoresViewModel, EditarFornecedorDto>();
        CreateMap<DetalhesFornecedorDto, EditarFornecedoresViewModel>();
    }
}
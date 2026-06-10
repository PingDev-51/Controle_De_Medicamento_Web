using AutoMapper;
using ControleDeMedicamento.WebApp.ModuloPacientes.Aplicacao;

namespace ControleDeMedicamento.WebApp.ModuloPacientes.Apresentacao;

public class PacienteProfile : Profile
{
    public PacienteProfile()
    {
        CreateMap<ListarPacienteDto, ListarPacienteViewModel>();
        CreateMap<CadastrarPacienteViewModel, CadastrarPacienteDto>();
        CreateMap<EditarPacienteViewModel, EditarPacienteDto>();
        CreateMap<DetalhesPacienteDto, EditarPacienteViewModel>();
    }
}
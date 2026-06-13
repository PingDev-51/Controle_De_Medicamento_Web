using AutoMapper;
using ControleDeMedicamento.WebApp.ConsoleApp.ModuloPacientes;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Apresentacao;

public class OpcaoPacienteProfile : Profile
{
    public OpcaoPacienteProfile()
    {
        CreateMap<Paciente, OpcaoPacienteViewModel>();
    }
}
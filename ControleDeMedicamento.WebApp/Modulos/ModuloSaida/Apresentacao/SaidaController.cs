using AutoMapper;
using ControleDeMedicamento.WebApp.ConsoleApp.ModuloPacientes;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Dominio;
using ControleDeMedicamento.WebApp.ModuloPacientes.Dominio;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Aplicacao;
using ControleDeMedicamento.WebApp.Modulos.ModuloEstoque.RequisicaoDeSaida.Apresentacao;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

public class SaidaController : Controller
{
    private readonly ServicoSaida servicoSaida;
    private readonly IMapper mapeador;

    public SaidaController(ServicoSaida servicoSaida, IMapper mapeador)
    {
        this.servicoSaida = servicoSaida;
        this.mapeador = mapeador;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarSaidaDto> dtos = servicoSaida.SelecionarTodos();

        List<ListarSaidaViewModel> listarVms = mapeador.Map<List<ListarSaidaViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarSaidaViewModel cadastrarVm =
            new CadastrarSaidaViewModel(
                DateTime.Now,
                string.Empty,
                string.Empty,
                0,
                SelecionarPacientes(),
                SelecionarMedicamentos()
                );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarSaidaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarSaidaDto dto = mapeador.Map<CadastrarSaidaDto>(cadastrarVm);

        Result resultado = servicoSaida.Cadastrar(dto);

        return RedirectToAction(nameof(Listar));
    }


    private List<OpcaoPacienteViewModel> SelecionarPacientes()
    {
        return mapeador.Map<List<OpcaoPacienteViewModel>>(
            servicoSaida.SelecionarPacientes());
    }

    private List<OpcaoMedicamentosViewModel> SelecionarMedicamentos()
    {
        return mapeador.Map<List<OpcaoMedicamentosViewModel>>(
            servicoSaida.SelecionarMedicamentos());
    }
}

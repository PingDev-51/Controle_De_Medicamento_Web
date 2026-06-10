
using AutoMapper;
using ControleDeMedicamento.WebApp.Compartilhado.Apresentacao.Extensions;
using ControleDeMedicamento.WebApp.ModuloPacientes.Aplicacao;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ControleDeMedicamento.WebApp.ModuloPacientes.Apresentacao;

public class PacienteController : Controller
{
    private readonly ServicoPaciente servicoPaciente;
    private readonly IMapper mapeador;

    public PacienteController(ServicoPaciente servicoPaciente, IMapper mapeador)
    {
        this.servicoPaciente = servicoPaciente;
        this.mapeador = mapeador;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarPacienteDto> dtos = servicoPaciente.SelecionarTodos();

        List<ListarPacienteViewModel> listarVms = mapeador.Map<List<ListarPacienteViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarPacienteViewModel cadastrarVm = new CadastrarPacienteViewModel(
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarPacienteViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarPacienteDto dto = mapeador.Map<CadastrarPacienteDto>(cadastrarVm);

        Result resultado = servicoPaciente.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError("", resultado.Errors[0].Message);
    
            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Result<DetalhesPacienteDto> resultado = servicoPaciente.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData["MensagemErro"] = resultado.Errors.First().Message;

            return RedirectToAction(nameof(Listar));
        }

        DetalhesPacienteDto dto = resultado.Value;

        EditarPacienteViewModel editarVm = mapeador.Map<EditarPacienteViewModel>(dto);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarPacienteViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarPacienteDto dto = mapeador.Map<EditarPacienteDto>(editarVm);

        Result resultado = servicoPaciente.Editar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
            {
                string campo =
                    erro.Metadata["Campo"] is string ? erro.Metadata["Campo"].ToString()! : string.Empty;

                ModelState.AddModelError(campo, erro.Message);
            }

            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Result<DetalhesPacienteDto> resultado = servicoPaciente.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMenssage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        DetalhesPacienteDto dto = resultado.Value;

        ExcluirPacienteViewModel excluirVm = new ExcluirPacienteViewModel(
            id,
            dto.Nome,
            dto.Telefone,
            dto.CartaoSus,
            dto.Cpf
        );

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirPacienteViewModel excluirVm)
    {
        Result resultado = servicoPaciente.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData["MensagemErro"] = resultado.Errors.First().Message;

        return RedirectToAction(nameof(Listar));
    }
}

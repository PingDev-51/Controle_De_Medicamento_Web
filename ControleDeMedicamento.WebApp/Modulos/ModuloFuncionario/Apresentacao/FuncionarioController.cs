using AutoMapper;
using ControleDeMedicamento.WebApp.Compartilhado.Apresentacao.Extensions;
using ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Aplicacao;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamento.WebApp.Modulos.ModuloFuncionarios.Apresentacao;

public class FuncionarioController : Controller
{
    private readonly ServicoFuncionario servicoFuncionario;
    private readonly IMapper mapeador;

    public FuncionarioController(ServicoFuncionario servicoFuncionario, IMapper mapeador)
    {
        this.servicoFuncionario = servicoFuncionario;
        this.mapeador = mapeador;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarFuncionarioDto> dtos = servicoFuncionario.SelecionarTodos();

        List<ListarFuncionarioViewModel> listarVms = mapeador.Map<List<ListarFuncionarioViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarFuncionarioViewModel cadastrarVm = new CadastrarFuncionarioViewModel(
            string.Empty,
            string.Empty,
            string.Empty
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarFuncionarioViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarFuncionarioDto dto = mapeador.Map<CadastrarFuncionarioDto>(cadastrarVm);

        Result resultado = servicoFuncionario.Cadastrar(dto);

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
        Result<DetalhesFuncionarioDto> resultado = servicoFuncionario.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData["MensagemErro"] = resultado.Errors.First().Message;

            return RedirectToAction(nameof(Listar));
        }

        DetalhesFuncionarioDto dto = resultado.Value;

        EditarFuncionarioViewModel editarVm = mapeador.Map<EditarFuncionarioViewModel>(dto);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarFuncionarioViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarFuncionarioDto dto = mapeador.Map<EditarFuncionarioDto>(editarVm);

        Result resultado = servicoFuncionario.Editar(dto);

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
        Result<DetalhesFuncionarioDto> resultado = servicoFuncionario.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMenssage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        DetalhesFuncionarioDto dto = resultado.Value;

        ExcluirFuncionarioViewModel excluirVm = new ExcluirFuncionarioViewModel(
            id,
            dto.Nome,
            dto.Telefone,
            dto.Cpf
        );

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirFuncionarioViewModel excluirVm)
    {
        Result resultado = servicoFuncionario.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData["MensagemErro"] = resultado.Errors.First().Message;

        return RedirectToAction(nameof(Listar));
    }
}

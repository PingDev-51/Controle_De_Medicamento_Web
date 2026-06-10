using System;
using ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Dominio;
using ControleDeMedicamento.WebApp.ModuloFornecedores.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamento.WebApp.ModuloDeMedicamentos.Apresentacao;

public class MedicamentosController : Controller
{
    private readonly IRepositorioMedicamento repositorioMedicamento;
    private readonly IRepositorioFornecedores repositoriofornecedor;

    public MedicamentosController(IRepositorioMedicamento repositorioMedicamento, IRepositorioFornecedores repositoriofornecedor)
    {
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositoriofornecedor = repositoriofornecedor;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarTodos();

        return View(MapearMedicamentos(medicamentos));
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarMedicamentosViewModel cadasstrarVm = new CadastrarMedicamentosViewModel(
            string.Empty,
            string.Empty,
            string.Empty,
            SelecionarFornecedor()
        );

        return View(cadasstrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarMedicamentosViewModel cadastrarVm)
    {
        Fornecedor? selecionarFornecedor = repositoriofornecedor.SelecionarPorId(cadastrarVm.FornecedorId);

        if (selecionarFornecedor == null)
            ModelState.AddModelError(nameof(cadastrarVm.FornecedorId), "Selecione um fornecedor valido");

        if (!ModelState.IsValid)
            return View(cadastrarVm with
            {
                Fornecedores = SelecionarFornecedor()
            });

        Medicamento novoMedicamento = new Medicamento(
            cadastrarVm.Nome,
            cadastrarVm.Descricao,
            selecionarFornecedor!
        );

        repositorioMedicamento.Cadastrar(novoMedicamento);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Medicamento? medicamentos = repositorioMedicamento.SelecionarPorId(id);

        if (medicamentos == null)
            return RedirectToAction(nameof(Listar));

        EditarMedicamentosViewModel editarVm = new EditarMedicamentosViewModel(
            id,
            medicamentos.Nome,
            medicamentos.Descricao,
            medicamentos.Fornecedor.Id,
            SelecionarFornecedor()
        );

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarMedicamentosViewModel editarVm)
    {
        Medicamento? medicamentos = repositorioMedicamento.SelecionarPorId(editarVm.Id);
        Fornecedor? fornecedorSelecionado = repositoriofornecedor.SelecionarPorId(editarVm.FornecedorId);

        if (medicamentos == null)
            return RedirectToAction(nameof(Listar));

        if (fornecedorSelecionado == null)
            ModelState.AddModelError(nameof(editarVm.FornecedorId), "Selecione um fornecedor valido");

        Medicamento medicamentoAtualizado = new Medicamento(
            editarVm.Nome,
            editarVm.Descricao,
            fornecedorSelecionado!
        );

        repositorioMedicamento.Editar(editarVm.Id, medicamentoAtualizado);

        return RedirectToAction(nameof(Listar));
    }


    private List<ListarMedicamentosViewModel> MapearMedicamentos(List<Medicamento> medicamento)
    {
        List<ListarMedicamentosViewModel> listarVm = medicamento.Select(m => new ListarMedicamentosViewModel(
            m.Id,
            m.Nome,
            m.Descricao,
            m.Fornecedor.Nome
        )).ToList();

        return listarVm;
    }

    private List<OpcaoFornecedorViewModel> SelecionarFornecedor()
    {
        return repositoriofornecedor.SelecionarTodos().Select(f => new OpcaoFornecedorViewModel(f.Id, f.Nome)).ToList();
    }
}

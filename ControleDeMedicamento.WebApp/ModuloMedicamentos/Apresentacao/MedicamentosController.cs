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




    private List<ListarMedicamentosViewModels> MapearMedicamentos(List<Medicamento> medicamento)
    {
        List<ListarMedicamentosViewModels> listarVm = medicamento.Select(m => new ListarMedicamentosViewModels(
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

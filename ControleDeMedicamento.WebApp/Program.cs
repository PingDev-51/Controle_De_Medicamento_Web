
using ControleDeMedicamento.WebApp.Compartilhado.Aplicacao;
using ControleDeMedicamento.WebApp.Compartilhado.Apresentacao;
using ControleDeMedicamento.WebApp.Modulos.ModuloPaciente.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AdicionarCamadaInfraestrutura();
builder.Services.AddApplicationServices();
builder.Services.AddPresentationConfig();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
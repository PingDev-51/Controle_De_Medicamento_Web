using ControleDeMedicamento.WebApp.Arquivos.Infra.Arquivos;
using ControleDeMedicamento.WebApp.ModuloFornecedores.Dominio;
using ControleDeMedicamento.WebApp.ModuloFornecedores.infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ContextoJson>(provider =>
{
    ContextoJson contexto = new ContextoJson();

    contexto.Carregar();

    return contexto;
});

builder.Services.AddControllersWithViews().AddRazorOptions(options =>
{
    options.ViewLocationFormats.Clear();

    options.ViewLocationFormats.Add("/Modulo{1}/Apresentacao/Views/{0}.cshtml");

    options.ViewLocationFormats.Add("/Compartilhado/Apresentacao/Views/{0}.cshtml");
});

builder.Services.AddScoped<IRepositorioFornecedores, RepositorioFornecedoresEmArquivo>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
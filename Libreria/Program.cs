using Libreria.Components;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;
using Libreria.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Add DbContext
builder.Services.AddDbContext<DirectorioContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

//Agregar servicio de repositorio
builder.Services.AddScoped<IRepositorioLibros, RepositorioLibros>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioClientes>();
builder.Services.AddScoped<IRepositorioVenta, RepositorioVenta>();
builder.Services.AddScoped<IRepositorioPedidoCliente, RepositorioPedidosClientes>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

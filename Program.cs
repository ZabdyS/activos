using activos.Controllers;
using activos.Models;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Configurar la inyección de dependencias para tu servicio ContabilidadService
builder.Services.AddSingleton<ContabilidadService>();

// Agregar la configuración para la inyección de dependencias de HttpClient
builder.Services.AddHttpClient<AsientosContablesController>(client =>
{
    client.BaseAddress = new Uri("https://ap1-contabilidad.azurewebsites.net/");
    // Agregar configuraciones adicionales según sea necesario
});
//conexion
builder.Services.AddDbContext<MyDbContext>(options =>
options.UseMySql("name=ConnectionStrings:MysqlConnection", new MySqlServerVersion(new Version(8, 0, 26))));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

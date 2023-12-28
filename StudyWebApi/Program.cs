using Microsoft.EntityFrameworkCore;
using StudyWebApi.Context;
using StudyWebApi.Repositorio;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CursoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoDefault"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); 
});

builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();
builder.Services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();

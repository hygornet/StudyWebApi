using Microsoft.EntityFrameworkCore;
using StudyWebApi.Context;
using StudyWebApi.Helper;
using StudyWebApi.Repositorio;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CursoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoDefault"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); 
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();
builder.Services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddSession(o => { 
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();

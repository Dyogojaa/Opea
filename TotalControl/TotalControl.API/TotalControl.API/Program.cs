using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TotalControl.API.Extensions;
using TotalControl.API.Validacoes;
using TotalControl.API.ViewModel;
using TotalControl.BLL.Models;
using TotalControl.DAL;
using TotalControl.DAL.Interface;
using TotalControl.DAL.Repositorios;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = "myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddCors();
builder.Services.AddSpaStaticFiles(diretorio =>
{
    diretorio.RootPath = "TotalControle-UI";
});

builder.Services.AddControllers()    
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    })
    .AddFluentValidation();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//Injenção de Dependencia do SQL Server
builder.Services.AddDbContext<BDContexto>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<Usuario, Funcao>().AddEntityFrameworkStores<BDContexto>();
builder.Services.ConfigurarSenhaUsuario();


////Injenção do AutoMapper e Classe de Repositorio do Cliente
//IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
//builder.Services.AddSingleton(mapper);
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<ITipoRepositorio, TipoRepositorio>();
builder.Services.AddScoped<IFuncaoRepositorio, FuncaoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddTransient<IValidator<Categoria>, CategoriaValidator>();
builder.Services.AddTransient<IValidator<Funcao>, FuncoesValidator>();
builder.Services.AddTransient<IValidator<RegistroViewModel>, RegistroViewModelValidator>();
builder.Services.AddTransient<IValidator<LoginViewModel>, LoginViewModelValidator>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
app.UseSpaStaticFiles();
app.MapControllers();
app.UseCors(myAllowSpecificOrigins);
//app.UseSpa(spa =>
//{
//    spa.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "TotalControle-UI");

//    if(app.Environment.IsDevelopment())
//    {
//        spa.UseProxyToSpaDevelopmentServer($"http://localhost:4200");
//    }

//});
app.Run();

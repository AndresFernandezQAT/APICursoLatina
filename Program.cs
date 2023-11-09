using APICurso.BLL;
using APICurso.Dapper;
using APICurso.IBLL;
using APICurso.IDapper;
using APICurso.IRepository;
using APICurso.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//crear referencias singleton para las interfaces y sus clases.
builder.Services.AddSingleton<IDapperContext, DapperContext>();
builder.Services.AddSingleton<IClientesRepository, ClientesRepository>();
builder.Services.AddSingleton<IClientesBLL, ClientesBLL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

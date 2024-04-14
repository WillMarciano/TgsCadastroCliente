using CadastroCliente.Api.Configuration;
using CadastroCliente.Api.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddApiProblemDetails();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.RegisterServices();

var app = builder.Build();
app.UseSwaggerConfiguration(app.Environment);
app.UseApiConfiguration(app.Environment);
app.Run();

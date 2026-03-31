using LaboratorioUdemy.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCore(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var miNombre = "Edison".ToUpperCreadorPorMi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

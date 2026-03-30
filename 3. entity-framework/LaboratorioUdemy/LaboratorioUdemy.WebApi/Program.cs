using LaboratorioUdemy.Application.Interfaces.Services;
using LaboratorioUdemy.Application.Models.DTOs;
using LaboratorioUdemy.Application.Services;
using LaboratorioUdemy.Domain.Database.SqlServer.Context;
using LaboratorioUdemy.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Service
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddSingleton<Cache<InstructorDto>>();

// Database
builder.Services.AddSqlServer<UdemyClonContext>(builder.Configuration.GetConnectionString("Database"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

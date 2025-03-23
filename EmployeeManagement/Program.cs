using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using EmployeeManagement.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataSource>
    (opt => opt.UseInMemoryDatabase("EmployeeDb"));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<EmployeeService>();

builder.Services.AddSingleton<DepartmentService>();

var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

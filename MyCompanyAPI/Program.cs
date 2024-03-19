using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCompanyAPI.Data;
using MyCompanyAPI.Interfaces.IRepository;
using MyCompanyAPI.Interfaces.IServices;
using MyCompanyAPI.Models;
using MyCompanyAPI.Profiles.AutoMappings;
using MyCompanyAPI.Repositories;
using MyCompanyAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IBaseRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IBaseRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBaseRepository<Project>, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MyCompanyMappings));
builder.Services.AddDbContext<MyCompanyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiProduct.Data; 
using Microsoft.OpenApi.Models;
using ApiProduct.Service;
using ApiProduct.Service.Interface;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Configura o Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura o banco de dados MySQL com ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 25))
    ));

// Adiciona suporte para controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configurações de Swagger e SwaggerUI para todos os ambientes
app.UseSwagger();
app.UseSwaggerUI();

// Redirecionamento para HTTPS
app.UseHttpsRedirection();

// Mapeia os controllers automaticamente
app.MapControllers();

app.Run();

using Lab3_2324802010163.Application.Services;
using Lab3_2324802010163.Domain.Repositories;
using Lab3_2324802010163.Infrastructure.Data;
using Lab3_2324802010163.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ===================== DB CONTEXT =====================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// ===================== DEPENDENCY INJECTION =====================
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();

// ===================== CONTROLLERS & SWAGGER =====================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ===================== MIDDLEWARE =====================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

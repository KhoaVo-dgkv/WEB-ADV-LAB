using Microsoft.EntityFrameworkCore;
using Lab09API.Data;
using Lab09API.Repositories;
using Lab09API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMVCClient", policy =>
    {
        policy.WithOrigins("https://localhost:7172", "http://localhost:5131")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Configure Entity Framework Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Register Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS - MUST be before UseAuthorization and MapControllers
app.UseCors("AllowMVCClient");

// Enable static files for serving images
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

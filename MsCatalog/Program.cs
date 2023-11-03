using MsCatalog.Data;
using MsCatalog.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMsCatalogContext, MsCatalogContext>(); 
builder.Services.AddScoped<IProductRepository, ProductRepository>(); 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Database;
using ProductsAPI.MappingProfiles;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(opt => opt.UseSqlServer("Server=mssql_container;Database=Products;TrustServerCertificate=True;User Id=sa;Password=Workshop!2023;"));
builder.Services.AddAutoMapper(new[] { typeof(MapperProfile) });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//using (var scope = app.Services.CreateScope()) {
//    var db = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
//    db.Database.Migrate();
//}

app.Run();

using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Middleware;
using RealEstateAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<RealEstateContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("RealEstateConnection")));

builder.Services.AddControllers();

builder.Services.AddScoped<IBrandService, BrandService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();


app.UseAuthorization();

app.MapControllers();

app.Run();

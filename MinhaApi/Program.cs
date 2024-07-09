using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinhaApi.Data;
using MinhaApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MinhaApiContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();


app.UseCors();


app.UseAuthorization();


app.MapControllers();

app.Run();
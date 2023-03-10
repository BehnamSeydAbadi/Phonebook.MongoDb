using Business.Configurations;
using DataAccess.Configurations;
using WebAPI.Infrastructure.Filters;
using WebAPI.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ResolveDataAccess(builder.Configuration.GetSection("PhoneBookDb"));
builder.Services.ResolveBusiness();
builder.Services.AddControllers(option => option.Filters.Add(OutputActionFilter.Instance));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();

public partial class Program { }
using Microsoft.EntityFrameworkCore;
using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Application.Services;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Data;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PatitasEnCuidadoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IVacunaRepository, VacunaRepository>();
builder.Services.AddTransient<IVacunaService, VacunaService>();

builder.Services.AddTransient<IFundacionRepository, FundacionRepository>();
builder.Services.AddTransient<IFundacionService, FundacionService>();


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();

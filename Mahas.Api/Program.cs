using Mahas.Data;
using Mahas.Data.Dao;
using Mahas.Domain.JurusanService;
using Mahas.Domain.MahasiswaService;
using Mahas.Domain.MahasiswaService.Impl;
using Mahas.Domain.JurusanService.Impl;
using Microsoft.EntityFrameworkCore;
using Mahas.Domain.MataKuliahService;
using Mahas.Domain.MataKuliahService.Impl;
using Mahas.Domain.NilaiService;
using Mahas.Domain.NilaiService.Impl;
using Mahas.Domain.FileService;
using Mahas.Domain.FileService.Impl;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:Local");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(b => b.UseSqlServer(connectionString));
builder.Services.AddScoped<IMahasiswaService,MahasiswaServiceImpl>();
builder.Services.AddScoped<IJurusanService, JurusanServiceImpl>();
builder.Services.AddScoped<IMataKuliahService, MataKuliahServiceImpl>();
builder.Services.AddScoped<INilaiService, NilaiServiceImpl>();
builder.Services.AddScoped<IFileService, FileServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

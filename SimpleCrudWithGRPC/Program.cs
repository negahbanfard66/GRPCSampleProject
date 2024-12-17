using Microsoft.EntityFrameworkCore;
using SimpleCrudWithGRPC.Application.IServices;
using SimpleCrudWithGRPC.Core.IRepositories;
using SimpleCrudWithGRPC.Infrastructure.Data;
using SimpleCrudWithGRPC.Infrastructure.Repositories;
using SimpleCrudWithGRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPersonService, SimpleCrudWithGRPC.Application.Services.PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<PersonGrpcService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

using AhmedRabieRegistrationApp.Application.CommandHandlers;
using AhmedRabieRegistrationApp.Domain.Repositories.Interfaces;
using AhmedRabieRegistrationApp.Infrastructure.Context;
using AhmedRabieRegistrationApp.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RegistrationAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddMediatR(typeof(RegisterCustomerCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(SetPINCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(VerifyOTPCommandHandler).Assembly);

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
 
using AdaTech.Api.Configuration;
using AdaTech.Api.Middlewares;
using AdaTech.Application.Repositories;
using AdaTech.Application.Requests;
using AdaTech.Application.UseCases;
using AdaTech.Application.Validators;
using AdaTech.Infrastructure.Http;
using AdaTech.Infrastructure.Http.Configuration;
using AdaTech.Infrastructure.SqlServer.Repositories;
using FluentValidation;
using HealthChecks.UI.Client;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCognitoAuth(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarAlunoUseCase).Assembly));
builder.Services.AddAdaSqlServer(builder.Configuration);
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddHttpClient<ICepRepository, CepRepository>()
    .AddPolicyHandler(RetryConfiguration.CreateRetryPolicy(3));
//Retry

builder.Services.AddSingleton(CircuitBreakerConfiguration.CreateCircuitBreakerPolicy(2, 10));

builder.Services.AddScoped<IValidator<CriarAlunoRequest>, CriarAlunoValidator>();
//builder.Services.AddScoped<ICriarAlunoUseCase, CriarAlunoUseCase>();


builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();

var app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

var loggerFactory = builder.Services?.BuildServiceProvider().GetRequiredService<ILoggerFactory>();
app.UseCustomLogs(loggerFactory, builder.Configuration);

app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
});

app.Run();

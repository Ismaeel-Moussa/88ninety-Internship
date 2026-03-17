using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using University.API.Autofac;
using University.API.Filters;
using University.Data.AppDbContext;
using University.Data.Autofac;


var builder = WebApplication.CreateBuilder(args);

// Logging
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<UniversityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterModule<RepositoriesModule>();
    container.RegisterModule<ServicesModule>();
    container.RegisterModule<ControllersModule>();
});

// Add CORS services
var reactOriginPolicy = "ReactOriginPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: reactOriginPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

app.UseCors(reactOriginPolicy);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization(); 
app.MapControllers();

app.Run();
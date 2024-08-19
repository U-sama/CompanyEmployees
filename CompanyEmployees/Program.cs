using CompanyEmployees.Extensions;
using NLog;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/NLog.config"));

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLogerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManger();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

var app = builder.Build();

if(app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers(); // app.MapControllers method, which adds endpoints for controller actions without specifying any routes.

app.Run();

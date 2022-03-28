using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Migrations.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CRMDbContext>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1.1", new OpenApiInfo() {Title = "CRM API", Version = "v1.1"});
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "ApiDocumentation.xml");
    c.IncludeXmlComments(filePath);
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1.1/swagger.json", "Api V1.1");
});
app.MapControllerRoute(name: "DefaultApi",
    pattern: "api/{controller}/{id}"
    );

app.MapControllers();
app.MapGet("/", () => "Hello World!");


app.Run();
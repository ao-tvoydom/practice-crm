using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Migrations.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CRMDbContext>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1.2", new OpenApiInfo() {Title = "CRM API", Version = "v1.2"});
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "ApiDocumentation.xml");
    c.IncludeXmlComments(filePath);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
    });

builder.Services.AddCors(options =>
{

    options.AddPolicy(name: "MyAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("localhost:8080");
        });

});

var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();
app.UseCors("MyAllowSpecificOrigins");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1.2/swagger.json", "Api V1.2");
});
app.MapControllerRoute(name: "DefaultApi",
    pattern: "api/{controller}/{id}"
    );

app.MapControllers();
app.MapGet("/", () => "Hello World!");


app.Run();
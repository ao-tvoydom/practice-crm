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
        options.Events = new CookieAuthenticationEvents
        {                          
            OnRedirectToLogin = redirectContext =>
            {
                redirectContext.HttpContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAntiforgery(options =>
{
    // Set Cookie properties using CookieBuilder properties†.
    options.FormFieldName = "AntiforgeryFieldname";
    options.HeaderName = "X-CSRF-TOKEN-HEADERNAME";
    options.SuppressXFrameOptionsHeader = false;
});


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
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
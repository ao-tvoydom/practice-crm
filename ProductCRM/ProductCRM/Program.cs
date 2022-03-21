using Microsoft.EntityFrameworkCore;
using Migrations.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CRMDbContext>();


var app = builder.Build();



app.MapControllerRoute(name: "DefaultApi",
    pattern: "api/{controller}/{id}"
    );

app.MapControllers();
app.MapGet("/", () => "Hello World!");


app.Run();
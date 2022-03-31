using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ProductCRM.Models;
using Migrations.Context;
using Migrations.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace ProductCRM.Controllers;

[Route("/[controller]")]
[ApiController]
public class AccountController : Controller
{
    private readonly CRMDbContext _context;

    public AccountController(CRMDbContext context)
    {
        _context = context;
    }
    

    /// <summary>
    /// Requires antiforgery token
    /// </summary>
    [HttpPost("Login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {
        object result = new {Error = "Invalid Model State"};
        
        if (ModelState.IsValid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
            if (user is not null)
            {
                await Authenticate(model.Login);

                result = new {Success = true};
            }
            else
            {
                result = new {Error = "Некорректные логин и(или) пароль"};
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            
        }

        return new ObjectResult(result);
    }

    

    /// <summary>
    /// Requires antiforgery token
    /// </summary>
    [HttpPost("Register")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        object result = new {Error = "Invalid Model State"};
        
        
        if (ModelState.IsValid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Email);
            if (user == null)
            {
                
                _context.Users.Add(new User {Login = model.Email, Password = model.Password});
                await _context.SaveChangesAsync();

                await Authenticate(model.Email); 
                
                result = new {Success = true};
            }
            else
            {
                result = new {Error = "Пользователь с этим логином уже существует"};
            }
               
        }

        return new ObjectResult(result);
    }

    private async Task Authenticate(string userName)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
        };
        
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }
}
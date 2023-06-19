using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserLogin.Models;

namespace UserLogin.Controllers;


public class HomeController : Controller
{
    //private readonly UserManager<CustomUser> _userManager;
    //private readonly SignInManager<CustomUser> _signManager;
    //private readonly RoleManager<IdentityRole> _roleManager;

    //public HomeController(UserManager<CustomUser> userManager, SignInManager<CustomUser> signManager, RoleManager<IdentityRole> roleManager)
    //{
    //    _userManager = userManager;
    //    _signManager = signManager;
    //    _roleManager = roleManager;
    //}

    public IActionResult Index()
    {
        return View();
    }
    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
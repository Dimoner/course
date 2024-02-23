using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExampleMvc.Models;

namespace ExampleMvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
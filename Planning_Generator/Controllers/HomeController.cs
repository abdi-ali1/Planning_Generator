using DTO_BinaryFile.Manager;
using Logic.System;
using Microsoft.AspNetCore.Mvc;
using Planning_Generator.Models;
using System.Diagnostics;

namespace Planning_Generator.Controllers
{
    public class HomeController : Controller
    {
    

        public IActionResult Index()
        {



            return View();
        }

     
    }
}
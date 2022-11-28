using Logic.System;
using Logic.System.Management;
using Microsoft.AspNetCore.Mvc;
using Planning_Generator.Models;
using System.Diagnostics;

namespace Planning_Generator.Controllers
{
    public class HomeController : Controller
    {
    

        public IActionResult Index()
        {


            MainSystem mainSystem = new MainSystem();

            foreach (var item in mainSystem.Models.AllStaffMembers)
            {
                Console.WriteLine(item.Name);
            }

            return View();
        }

     
    }
}
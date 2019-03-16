using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DRYModelValidation.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DRYModelValidation.Controllers
{
    /* Check Views/Home, CustomDateValidator and Models/Student for all
     * the details
     */
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind("Name,Age,DateOfBirth")]Student student)
        {
            //condition to check if model valid
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            return RedirectToAction("CheckModelResult");
        }

        //this method is used for showing that model was valid
        public IActionResult CheckModelResult()
        {
            ViewData["success"] = true;
            ViewData["message"] = "Student details successfully added";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendDataViewToController.Models;

namespace SendDataViewToController.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //Request the view
        [HttpGet]
        public IActionResult SendStaticModel()
        {
            return View();
        }

        /*The post method receives the data coming from the view
         * Although not covered in this tutorial I recommend
         * using model binding for the properties you want to send, it's safer
         * for example: [Bind("Name","Age","DateOfBirth","ProgrammeOfStudy")]Student student inside the brackets of the method
         * for more details check: https://www.hanselman.com/blog/ASPNETOverpostingMassAssignmentModelBindingSecurity.aspx
         */
        //form submission, a form was added in the view to be able to receive data
        //through the HttpPost request, check comments in the view
        [HttpPost]
        public IActionResult SendStaticModel(Student student)
        {

            return View(student);
        }


        //Request the view
        [HttpGet]
        public IActionResult SendDynamicModel()
        {
            return View();
        }


        /*It is not an actual dynamic model as there is no need for using @model dynamic in view
         * that is the case if we want to send something from the controller to view
         * as it can be seen the parameters of the HttpPost Request are the name attributes set in the view
         * you can also use Request.Form and add the name of the html element inside the square brackets
         * also check the view for more details
         */
        [HttpPost]
        public IActionResult SendDynamicModel(string studentProgrammeOfStudy, int? studentAge)
        {
            string name = Request.Form["studentName"];
            DateTime dateOfBirth = DateTime.Parse(Request.Form["studentDateOfBirth"]);

            return View();
        }

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
}

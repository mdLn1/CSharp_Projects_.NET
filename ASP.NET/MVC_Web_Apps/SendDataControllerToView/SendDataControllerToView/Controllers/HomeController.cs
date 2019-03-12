using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendDataControllerToView.Models;

namespace SendDataControllerToView.Controllers
{
    public class HomeController : Controller
    {

        /*For both examples when you check in the runnig up
         * you should be able to see the fields that contain
         * the data that we send surrounded by blue borders
         * for better readability
         * /

        /* inside StudentDetailsUsingDynamicModel you will see 
         * that you have three differnt methods for sending data to the View
         * 1. ViewData
         * 2. ViewBag
         * 3. dynamic model
         * I have added comments inside the views as well, check
         * them for better understanding
         */
        public IActionResult StudentDetailsUsingDynamicModel()
        {
            //with ViewData you have to mention
            //the namne of the variable that contains what is to be sent
            //within the square brackets
            ViewData["studentName"] = "Cristian P. George";

            //with ViewBag you create the variable you want to send
            //you do not need to mention its type
            ViewBag.studentDateOfBirth = new DateTime(1998, 3, 25).ToShortDateString();

            //using a dynamic model means you can create variables
            //same way you proceed with ViewBag, however
            //inside the view you need to mention that a dynamic
            //model is expected by adding "@model dynamic" to your view,
            //preferably on the first line
            dynamic model = new ExpandoObject();
            model.Age = (int)20;
            model.ProgrammeOfStudy = "Computer Science";
            
            //you pass the model in your View by inserting it inside the brackets View(model)
            //ViewBag and ViewData do not need to be added they will be sent at run time
            return View(model);
        }

        /*inside StudentDetailsUsingStaticModel you will see 
         * that is only the Student Model that is sent, which
         * is a static model, you could also use ViewData and ViewBag
         * which were demonstrated in the previous method
         * */
        public IActionResult StudentDetailsUsingStaticModel()
        {
            Student student = new Student
            {
                Name = "Johnny Z. Perry",
                Age = 20,
                DateOfBirth = new DateTime(2000, 5, 15),
                ProgrammeOfStudy = "Software Engineering"
            };

            //same way we did with the dynamic model we need to pass
            //student to View and add "@model Student" inside the view
            //so we can access its properties
            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

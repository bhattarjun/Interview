using Practical.BAL;
using Practical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical.Controllers
{
    public class EmployeeController : Controller
    {
        EmpHelper eh = new EmpHelper();

        // GET: Employee
        public ActionResult One()
        {
            
            return View(eh.GetAll());
        }

        public ActionResult Two()
        {

            return View(eh.GetOne());
        }

        public ActionResult Three()
        {

            return View(eh.Gettwo());
        }


        // GET: Employee
        public ActionResult Insert()
        {

            return View();
        }

        // POST: Employee
        [HttpPost]
        public ActionResult Insert(EmpModel data)
        {
            if (eh.Create(data))
            {
                return RedirectToAction("One");
            }
            else
            {
                return View();
            }

            
        }
    }
}
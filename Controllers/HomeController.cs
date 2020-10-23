using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wunderman_Thompson_MSC_Assessment.Models;

namespace Wunderman_Thompson_MSC_Assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeContext _context;

        public HomeController(EmployeeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Detail(int Id, Employee employee)
        {
            if (employee.EmployeeId > 0)
            {
                ViewBag.message = "Your details have been saved successfully.";
                var result = _context.Employees.Find(employee.EmployeeId);
                employee.FirstName = result.FirstName + " " + result.LastName;
                employee.Organisation = result.Organisation;
                employee.WorkEmail = result.WorkEmail;
                employee.PhoneNumber = result.PhoneNumber;
                employee.Optional = result.Optional;
                employee.Industry = result.Industry;
                if (Convert.ToBoolean(result.CheckBoxValue1) == true )
                employee.CheckBoxValue1 = result.CheckBoxValue1 ;
                if(Convert.ToBoolean(result.CheckBoxValue2) == true)
                    employee.CheckBoxValue1 += "," + result.CheckBoxValue2;
                if (Convert.ToBoolean(result.CheckBoxValue3) == true)
                    employee.CheckBoxValue1 += "," + result.CheckBoxValue2 + "," + result.CheckBoxValue3;
                if (Convert.ToBoolean(result.CheckBoxValue4) == true)
                    employee.CheckBoxValue1 += "," + result.CheckBoxValue2 + "," + result.CheckBoxValue3 + "," + result.CheckBoxValue4;
                if (Convert.ToBoolean(result.CheckBoxValue5) == true)
                    employee.CheckBoxValue1 += "," + result.CheckBoxValue2 + "," + result.CheckBoxValue3 + "," + result.CheckBoxValue4 + "," + result.CheckBoxValue5;

            }
            else
            {
                ViewBag.message = "Your details have been saved successfully.";
            }
            return View(employee);
        }

        /// <summary>
        /// GET: Employee/AddOrEdit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
                return View(_context.Employees.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("EmployeeId,FirstName,LastName,Organisation,WorkEmail,PhoneNumber,CheckBoxValue1,CheckBoxValue2,CheckBoxValue3,CheckBoxValue4,CheckBoxValue5, Industry,Optional")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.EmployeeId == 0)
                    _context.Add(employee);
                else
                    _context.Update(employee);
                await _context.SaveChangesAsync();
                ViewBag.message = "Your details have been saved successfully.";
                // return RedirectToAction(nameof(Detail));
                return RedirectToAction("Detail", "Home", new { @employee.EmployeeId });
            }

            return View(employee);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

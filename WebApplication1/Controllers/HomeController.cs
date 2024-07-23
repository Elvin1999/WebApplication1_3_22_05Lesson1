using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //url/Home/Index
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello from Index Action";
        }

        public IActionResult Index2()
        {
            return Ok();
        }

        public IActionResult Index3()
        {
            return NotFound();
        }

        public IActionResult Index4()
        {
            return BadRequest();
        }

        public IActionResult Employees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee()
                {
                    Id=1,
                    Firstname="Mehemmed",
                    Lastname="Nebiyev"
                },
                new Employee()
                {
                    Id=2,
                     Firstname="Seid",
                      Lastname="Memmedov"
                },
                new Employee()
                {
                    Id=3,
                    Firstname="Turqay",
                    Lastname="Memmedov"
                }
            };

            List<string> cities = new List<string> { "Baku", "Oslo", "Ottawa" };

            var vm = new EmployeeListViewModel
            {
                Employees = employees,
                Cities = cities
            };

            return View(vm);
        }

        public IActionResult Employees2()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee()
                {
                    Id=1,
                    Firstname="Mehemmed",
                    Lastname="Nebiyev"
                },
                new Employee()
                {
                    Id=2,
                     Firstname="Seid",
                      Lastname="Memmedov"
                },
                new Employee()
                {
                    Id=3,
                    Firstname="Turqay",
                    Lastname="Memmedov"
                }
            };

            return View(employees);
        }

        public IActionResult GetById(int id)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee()
                {
                    Id=1,
                    Firstname="Mehemmed",
                    Lastname="Nebiyev"
                },
                new Employee()
                {
                    Id=2,
                     Firstname="Seid",
                      Lastname="Memmedov"
                },
                new Employee()
                {
                    Id=3,
                    Firstname="Turqay",
                    Lastname="Memmedov"
                }
            };

            var item = employees.FirstOrDefault(e => e.Id == id);
            if (item != null)
            {

                var vm = new EmployeeDetailViewModel
                {
                    Firstname = item.Firstname,
                    Lastname = item.Lastname
                };
                return View("EmployeeDetail", vm);
            }
            else
            {
                return View("NotFound","Employee does not exist");
                //return Redirect("/home/employees");
                //return RedirectToAction("employees");
                //return RedirectToAction("getById",new {id=1});

                //var routeValue = new RouteValueDictionary(new { action = "Employees", controller = "Home" });

                //return RedirectToRoute(routeValue);

            }
            //return Json(item);
        }



        public IActionResult Filter(string key, string sort = "a-z")
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee()
                {
                    Id=1,
                    Firstname="Mehemmed",
                    Lastname="Nebiyev"
                },
                new Employee()
                {
                    Id=2,
                     Firstname="Seid",
                      Lastname="Memmedov"
                },
                new Employee()
                {
                    Id=3,
                    Firstname="Turqay",
                    Lastname="Memmedov"
                }
            };

            var result = employees.Where(e => e.Firstname.Contains(key));
            if (sort == "a-z")
            {
                result = result.OrderBy(e => e.Firstname);
            }
            else if (sort == "z-a")
            {
                result = result.OrderByDescending(e => e.Firstname);
            }
            var vm = new EmployeeListViewModel
            {
                Employees = result.ToList(),
                Cities = null
            };

            return View("Employees", vm);
        }
    }
}

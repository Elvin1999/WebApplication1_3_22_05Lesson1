using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>
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

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new EmployeeListViewModel
            {
                Employees = Employees
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new EmployeeAddViewModel
            {
                Employee = new Employee()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(EmployeeAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Employee.Id = (new Random()).Next(100, 1000);
                Employees.Add(vm.Employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }
        }
    }
}

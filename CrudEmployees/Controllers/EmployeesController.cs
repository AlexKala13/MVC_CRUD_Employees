using CrudEmployees.Data;
using CrudEmployees.Models;
using CrudEmployees.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CrudEmployees.Controllers
{
    public class EmployeesController : Controller
    {
        public readonly CrudEmployeesDBContext _db;

        public EmployeesController(CrudEmployeesDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var employees = _db.employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddEmployeeViewModel model) // employee add
        {
            var employee = new Employee()
            {
                Name = model.Name,
                Email = model.Email,
                Salary = model.Salary,
                BirthDate = model.BirthDate,
                Department = model.Department,
            };

            _db.employees.Add(employee);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult View(int id) // employee edit
        {
            var employees = _db.employees.FirstOrDefault(x => x.Id == id);

            if(employees != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employees.Id,
                    Name = employees.Name,
                    Email = employees.Email,
                    Salary = employees.Salary,
                    BirthDate = employees.BirthDate,
                    Department = employees.Department,
                };
                return View("View", viewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult View(UpdateEmployeeViewModel model) // edited employee set
        {
            var employee = _db.employees.Find(model.Id);
            if(employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.BirthDate = model.BirthDate;
                employee.Department = model.Department;

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(UpdateEmployeeViewModel model) // employee delete
        {
            var employee = _db.employees.Find(model.Id);
            if(employee != null)
            {
                _db.employees.Remove(employee);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

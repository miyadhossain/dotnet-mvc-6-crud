using dotnetmvc6.Data;
using dotnetmvc6.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetmvc6.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> objEmployeeList = _db.Employees;
            return View(objEmployeeList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {   
            if (obj.Age == obj.Salary)
            {
                ModelState.AddModelError("Age", "The Age cannot exactly match the salary");
            }

            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee added successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var employeeFromDb = _db.Employees.Find(id);
            //var employeeFromDb = _db.Employees.FirstOrDefault(u => u.Id == id);
            //var employeeFromDb = _db.Employees.SingleOrDefault(u => u.Id == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            } 
            return View(employeeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if (obj.Age == obj.Salary)
            {
                ModelState.AddModelError("Age", "The Age cannot exactly match the salary");
            }

            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee updated successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var employeeFromDb = _db.Employees.Find(id);
            //var employeeFromDb = _db.Employees.FirstOrDefault(u => u.Id == id);
            //var employeeFromDb = _db.Employees.SingleOrDefault(u => u.Id == id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            return View(employeeFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Employees.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Employee deleted successfully!";
            return RedirectToAction("Index");
                       
        }
    }
}

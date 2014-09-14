using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamsAndEmployees.Models;

namespace TeamsAndEmployees.Controllers
{
    public class EmployeeController : Controller
    {
        private TeamsAndEmployeesContext db = new TeamsAndEmployeesContext();

        // Returns a list of all employees, or employees for the specified team
        // GET: /Employee/

        public ActionResult Index(int teamId = 0)
        {
            // Return all employees, if a team id is not specified
            if (teamId == 0) 
            { 
                return View(db.Employees.ToList()); 
            }

            Team team = db.Teams.Find(teamId);
            if (team == null)
            {
                return HttpNotFound();
            }

            // Return employees for the specified team
            return View(db.Employees.Where(e => e.TeamId == teamId));
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", new { teamId = employee.TeamId });
            }

            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name");
            return View(employee);
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            EmployeeViewModel employeeModel = new EmployeeViewModel(employee);
            ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", employee.TeamId);

            return View(employeeModel);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee(employeeModel);

                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", new { teamId = employeeModel.OriginalTeamId });
            }
            return View(employeeModel);
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            int teamId = employee.TeamId;

            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index", new { teamId = teamId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
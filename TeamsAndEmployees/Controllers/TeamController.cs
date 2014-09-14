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
    public class TeamController : Controller
    {
        private TeamsAndEmployeesContext db = new TeamsAndEmployeesContext();

        //
        // GET: /Team/

        public ActionResult Index()
        {
            List<ListDeleteTeamViewModel> teamModels = new List<ListDeleteTeamViewModel>();
            foreach(var team in db.Teams)
            {
                teamModels.Add(new ListDeleteTeamViewModel(team));
            }

            return View(teamModels);
        }

        //
        // GET: /Team/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Team/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditCreateTeamViewModel teamModel)
        {
            if (ModelState.IsValid)
            {
                Team team = new Team(teamModel);

                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teamModel);
        }

        //
        // GET: /Team/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }

            EditCreateTeamViewModel model = new EditCreateTeamViewModel(team);
            return View(model);
        }

        //
        // POST: /Team/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCreateTeamViewModel teamModel)
        {
            if (ModelState.IsValid)
            {
                Team team = new Team(teamModel);

                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teamModel);
        }

        //
        // GET: /Team/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }

            ListDeleteTeamViewModel teamModel = new ListDeleteTeamViewModel(team);
            return View(teamModel);
        }

        //
        // POST: /Team/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Find(id);

            if (team.Employees.Count != 0)
            {
                ViewBag.ValidationMessage = "You can't delete a team with employees present!";

                ListDeleteTeamViewModel teamModel = new ListDeleteTeamViewModel(team);
                return View(teamModel);
            }

            db.Teams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
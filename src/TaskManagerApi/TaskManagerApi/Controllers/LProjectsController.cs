using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagerApi.Models;

namespace TaskManagerApi.Controllers
{
    public class LProjectsController : Controller
    {
        private TaskManagerApiContext db = new TaskManagerApiContext();

        // GET: LProjects
        public ActionResult Index()
        {
            return View(db.LProjects.ToList());
        }

        // GET: LProjects/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LProject lProject = db.LProjects.Find(id);
            if (lProject == null)
            {
                return HttpNotFound();
            }
            return View(lProject);
        }

        // GET: LProjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,Name")] LProject lProject)
        {
            if (ModelState.IsValid)
            {
                db.LProjects.Add(lProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lProject);
        }

        // GET: LProjects/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LProject lProject = db.LProjects.Find(id);
            if (lProject == null)
            {
                return HttpNotFound();
            }
            return View(lProject);
        }

        // POST: LProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,Name")] LProject lProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lProject);
        }

        // GET: LProjects/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LProject lProject = db.LProjects.Find(id);
            if (lProject == null)
            {
                return HttpNotFound();
            }
            return View(lProject);
        }

        // POST: LProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LProject lProject = db.LProjects.Find(id);
            db.LProjects.Remove(lProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

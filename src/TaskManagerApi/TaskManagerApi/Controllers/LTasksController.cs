using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagerApi.Models;

namespace TaskManagerApi.Controllers
{
    public class LTasksController : Controller
    {
        private TaskManagerApiContext db = new TaskManagerApiContext();

        // GET: LTasks
        public async Task<ActionResult> Index()
        {
            var tasks = await db.LTasks.ToListAsync();
            var groupIDs = tasks.Select(m => m.TaskGroupID);
            var groups = db.LTaskGroups.Where(x => groupIDs.Contains(x.TaskGroupID)).ToList();
            foreach(var task in tasks)
            {
                task.TaskGroup = groups.FirstOrDefault(g => g.TaskGroupID == task.TaskGroupID);
            }

            return View(tasks);
        }

        // GET: LTasks/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LTask lTask = await db.LTasks.FindAsync(id);
            if (lTask == null)
            {
                return HttpNotFound();
            }
            return View(lTask);
        }

        // GET: LTasks/Create
        public ActionResult Create()
        {
            ViewData["AllTaskGroups"] = db.LTaskGroups.ToList();
            return View();
        }

        // POST: LTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,TaskGroupID")] LTask lTask)
        {
            if (ModelState.IsValid)
            {
                lTask.TaskID = Guid.NewGuid().ToString("N");
                db.LTasks.Add(lTask);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lTask);
        }

        // GET: LTasks/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LTask lTask = await db.LTasks.FindAsync(id);
            if (lTask == null)
            {
                return HttpNotFound();
            }
            return View(lTask);
        }

        // POST: LTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TaskID,Name,TaskGroupID")] LTask lTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lTask).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lTask);
        }

        // GET: LTasks/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LTask lTask = await db.LTasks.FindAsync(id);
            if (lTask == null)
            {
                return HttpNotFound();
            }
            return View(lTask);
        }

        // POST: LTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            LTask lTask = await db.LTasks.FindAsync(id);
            db.LTasks.Remove(lTask);
            await db.SaveChangesAsync();
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

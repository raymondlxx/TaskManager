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
    
    public class LTaskGroupsController : Controller
    {
        private TaskManagerApiContext db = new TaskManagerApiContext();


        // GET: groups
        public async Task<ActionResult> Index()
        {
            return View(await db.LTaskGroups.ToListAsync());
        }

        // GET: groups/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LTaskGroup lTaskGroup = await db.LTaskGroups.FindAsync(id);
            if (lTaskGroup == null)
            {
                return HttpNotFound();
            }
            return View(lTaskGroup);
        }

        // GET: groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LTaskGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name")] LTaskGroup lTaskGroup)
        {
            if (ModelState.IsValid)
            {
                lTaskGroup.TaskGroupID = Guid.NewGuid().ToString("N");
                db.LTaskGroups.Add(lTaskGroup);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lTaskGroup);
        }

        // GET: groups/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LTaskGroup lTaskGroup = await db.LTaskGroups.FindAsync(id);
            if (lTaskGroup == null)
            {
                return HttpNotFound();
            }
            return View(lTaskGroup);
        }

        // POST: groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TaskGroupID,Name")] LTaskGroup lTaskGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lTaskGroup).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lTaskGroup);
        }

        // GET: groups/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LTaskGroup lTaskGroup = await db.LTaskGroups.FindAsync(id);
            if (lTaskGroup == null)
            {
                return HttpNotFound();
            }
            return View(lTaskGroup);
        }

        // POST: groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            LTaskGroup lTaskGroup = await db.LTaskGroups.FindAsync(id);
            db.LTaskGroups.Remove(lTaskGroup);
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

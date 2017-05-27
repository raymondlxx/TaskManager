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
    public class LTransactionsController : Controller
    {
        private TaskManagerApiContext db = new TaskManagerApiContext();

        // GET: LTransactions
        public async Task<ActionResult> Index()
        {
            return View(await db.LTransactions.ToListAsync());
        }

        // GET: LTransactions/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LTransaction lTransaction = await db.LTransactions.FindAsync(id);
            if (lTransaction == null)
            {
                return HttpNotFound();
            }
            return View(lTransaction);
        }

        // GET: LTransactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TransationID,Name")] LTransaction lTransaction)
        {
            if (ModelState.IsValid)
            {
                db.LTransactions.Add(lTransaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lTransaction);
        }

        // GET: LTransactions/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LTransaction lTransaction = await db.LTransactions.FindAsync(id);
            if (lTransaction == null)
            {
                return HttpNotFound();
            }
            return View(lTransaction);
        }

        // POST: LTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TransationID,Name")] LTransaction lTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lTransaction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lTransaction);
        }

        // GET: LTransactions/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LTransaction lTransaction = await db.LTransactions.FindAsync(id);
            if (lTransaction == null)
            {
                return HttpNotFound();
            }
            return View(lTransaction);
        }

        // POST: LTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            LTransaction lTransaction = await db.LTransactions.FindAsync(id);
            db.LTransactions.Remove(lTransaction);
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

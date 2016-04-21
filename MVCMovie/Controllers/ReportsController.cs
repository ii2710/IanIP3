using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IP3Project.Models;
using IP3Project.CustomFilters;
using System.Web.Security;

namespace IP3Project.Controllers
{
    //change database then change these VVVVV
    public class ReportsController : Controller
    {
        private ReportDBContext db = new ReportDBContext();

        // GET: /Reports/
        public ActionResult Index(string Reporter, string searchString)
        {
            var Reporterlst = new List<string>();

            var Reporterqry = from d in db.Reports
                           orderby d.Reporter
                           select d.Reporter;

            Reporterlst.AddRange(Reporterqry.Distinct());
            ViewBag.Reporter = new SelectList(Reporterlst);

            var reports = from m in db.Reports
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                reports = reports.Where(s => s.ReportTitle.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(Reporter))
            {
                reports = reports.Where(x => x.Reporter == Reporter);
            }

            return View(reports);
        }
        // GET: /Reports/Details/5
        [Authorize(Users = "Admin, Reporter, reportmanager")]
public ActionResult Details(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Report report = db.Reports.Find(id);
    if (report == null)
    {
        return HttpNotFound();
    }
    return View(report);
}

        // GET: /Reports/Create
        public ActionResult Create()
        {
            return View(new Report
            {
                Reporter = "Tom Grid ",
                ID = 0,
                Date = DateTime.Now,
                Details = "Wing Damage",
                ReportTitle = "Incident",
                Priority = "Medium"
            });
        }
        /*
public ActionResult Create()
{
    return View();
}

 */
// POST: /Reports/Create
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

[Authorize (Users = "Admin, Reporter, reportmanager")]
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "ReportTitle,Date,Reporter,ID,Details")] Report report)
{
    if (ModelState.IsValid)
    {
        db.Reports.Add(report);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(report);
}

// GET: /Reports/Edit/5
        [Authorize(Users = "Admin, reportmanager")]
public ActionResult Edit(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Report report = db.Reports.Find(id);
    if (report == null)
    {
        return HttpNotFound();
    }
    return View(report);
}

// POST: /Reports/Edit/5
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "Admin, reportmanager")]
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit([Bind(Include = "ReportTitle,Date,Reporter,ID,Details")] Report report)
{
    if (ModelState.IsValid)
    {
        db.Entry(report).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    return View(report);
}

// GET: /Reports/Delete/5
        [Authorize(Users = "Admin, reportmanager")]
public ActionResult Delete(int? id)
{
    if (id == null)
    {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    }
    Report report = db.Reports.Find(id);
    if (report == null)
    {
        return HttpNotFound();
    }
    return View(report);
}

// POST: /Reports/Delete/5
[HttpPost, ActionName("Delete")]
[Authorize(Users = "Admin, reportmanager")]
[ValidateAntiForgeryToken]
public ActionResult DeleteConfirmed(int id)
{
    Report report = db.Reports.Find(id);
    db.Reports.Remove(report);
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

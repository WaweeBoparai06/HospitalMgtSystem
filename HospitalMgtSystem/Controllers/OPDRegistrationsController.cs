using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalMgtSystem.Models;

namespace HospitalMgtSystem.Controllers
{
    public class OPDRegistrationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OPDRegistrations
        public ActionResult Index()
        {
            var oPDRegistrations = db.OPDRegistrations.Include(o => o.Doctor).Include(o => o.Patient);
            return View(oPDRegistrations.ToList());
        }

        // GET: OPDRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPDRegistration oPDRegistration = db.OPDRegistrations.Find(id);
            if (oPDRegistration == null)
            {
                return HttpNotFound();
            }
            return View(oPDRegistration);
        }

        // GET: OPDRegistrations/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName");
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName");
            return View();
        }

        // POST: OPDRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OPDId,PatientId,DoctorId,DateOfRegister,Problem,RoomNo,TokenNo,Status")] OPDRegistration oPDRegistration)
        {
            if (ModelState.IsValid)
            {
                db.OPDRegistrations.Add(oPDRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", oPDRegistration.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName", oPDRegistration.PatientId);
            return View(oPDRegistration);
        }

        // GET: OPDRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPDRegistration oPDRegistration = db.OPDRegistrations.Find(id);
            if (oPDRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", oPDRegistration.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName", oPDRegistration.PatientId);
            return View(oPDRegistration);
        }

        // POST: OPDRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OPDId,PatientId,DoctorId,DateOfRegister,Problem,RoomNo,TokenNo,Status")] OPDRegistration oPDRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oPDRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", oPDRegistration.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName", oPDRegistration.PatientId);
            return View(oPDRegistration);
        }

        // GET: OPDRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPDRegistration oPDRegistration = db.OPDRegistrations.Find(id);
            if (oPDRegistration == null)
            {
                return HttpNotFound();
            }
            return View(oPDRegistration);
        }

        // POST: OPDRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OPDRegistration oPDRegistration = db.OPDRegistrations.Find(id);
            db.OPDRegistrations.Remove(oPDRegistration);
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

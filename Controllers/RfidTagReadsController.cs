using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RFID_Device_Management.DAL;
using RFID_Device_Management.Models;

namespace RFID_Device_Management.Controllers
{
    public class RfidTagReadsController : Controller
    {
        private RFID_Device_Management.DAL.RfidContext db = new RFID_Device_Management.DAL.RfidContext();


        // GET: RfidTagReads
        public ActionResult Index()
        {
            return View(db.RfidTagReads.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RfidTagRead rfidTagRead = db.RfidTagReads.Find(id);
            if (rfidTagRead == null)
            {
                return HttpNotFound();
            }
            return View(rfidTagRead);
        }

        // GET: RfidTagReads/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeviceId,ReadTimestamp,Location,ReaderId")] RfidTagRead rfidTagRead)
        {
            if (ModelState.IsValid)
            {
                db.RfidTagReads.Add(rfidTagRead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rfidTagRead);
        }

        // GET: RfidTagReads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RfidTagRead rfidTagRead = db.RfidTagReads.Find(id);
            if (rfidTagRead == null)
            {
                return HttpNotFound();
            }
            return View(rfidTagRead);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeviceId,ReadTimestamp,Location,ReaderId")] RfidTagRead rfidTagRead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rfidTagRead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rfidTagRead);
        }

        // GET: RfidTagReads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RfidTagRead rfidTagRead = db.RfidTagReads.Find(id);
            if (rfidTagRead == null)
            {
                return HttpNotFound();
            }
            return View(rfidTagRead);
        }

        // POST: RfidDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RfidDevice rfidDevice = db.RfidDevices.Find(id);

            if (rfidDevice != null)
            { 
                var tagReads = db.RfidTagReads.Where(r => r.DeviceId == id).ToList();
                foreach (var tagRead in tagReads)
                {
                    db.RfidTagReads.Remove(tagRead);
                }

                db.RfidDevices.Remove(rfidDevice);

                db.SaveChanges();
            }

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

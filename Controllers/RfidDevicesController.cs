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
    public class RfidDevicesController : Controller
    {
        
        private RFID_Device_Management.DAL.RfidContext db = new RFID_Device_Management.DAL.RfidContext();

        public ActionResult Index(string sortOrder, string searchString)
        {
           
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.TypeSortParam = sortOrder == "Type" ? "type_desc" : "Type";
            ViewBag.LocationSortParam = sortOrder == "Location" ? "location_desc" : "Location";

            
            var devices = from d in db.RfidDevices
                          select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                devices = devices.Where(d => d.DeviceName.Contains(searchString)
                                          || d.DeviceType.Contains(searchString)
                                          || d.Location.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    devices = devices.OrderByDescending(d => d.DeviceName);
                    break;
                case "Type":
                    devices = devices.OrderBy(d => d.DeviceType);
                    break;
                case "type_desc":
                    devices = devices.OrderByDescending(d => d.DeviceType);
                    break;
                case "Location":
                    devices = devices.OrderBy(d => d.Location);
                    break;
                case "location_desc":
                    devices = devices.OrderByDescending(d => d.Location);
                    break;
                default:
                    devices = devices.OrderBy(d => d.DeviceName);
                    break;
            }

            return View(devices.ToList());
        }

        // GET: RfidDevices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RfidDevice rfidDevice = db.RfidDevices.Find(id);
            if (rfidDevice == null)
            {
                return HttpNotFound();
            }
            return View(rfidDevice);
        }

        // GET: RfidDevices/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeviceName,DeviceType,UniqueIdentifier,Location,Status")] RfidDevice rfidDevice)
        {
           
            var existingDevice = db.RfidDevices.FirstOrDefault(d => d.UniqueIdentifier == rfidDevice.UniqueIdentifier);

            if (existingDevice != null)
            {
                
                ModelState.AddModelError("UniqueIdentifier", "A device with the same Unique Identifier already exists.");
                return View(rfidDevice);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.RfidDevices.Add(rfidDevice);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
         
                    ModelState.AddModelError("", "An error occurred while saving the device. Please try again.");
                }
            }

           
            return View(rfidDevice);
        }


        // GET: RfidDevices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RfidDevice rfidDevice = db.RfidDevices.Find(id);
            if (rfidDevice == null)
            {
                return HttpNotFound();
            }

            return View(rfidDevice);
        }

        // POST: RfidDevices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeviceName,DeviceType,UniqueIdentifier,Location,Status")] RfidDevice rfidDevice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rfidDevice).State = EntityState.Modified;
                db.SaveChanges();  

                TempData["SuccessMessage"] = "Record updated successfully!";
                return RedirectToAction("Index");
            }

        
            return View(rfidDevice);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RfidDevice rfidDevice = db.RfidDevices.Find(id);
            if (rfidDevice == null)
            {
                return HttpNotFound();
            }
            return View(rfidDevice);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            RfidDevice rfidDevice = db.RfidDevices.Find(id);

            if (rfidDevice == null)
            {
                return HttpNotFound();
            }

            var relatedTagReads = db.RfidTagReads.Where(r => r.DeviceId == id).ToList();

            db.RfidTagReads.RemoveRange(relatedTagReads);

            db.RfidDevices.Remove(rfidDevice);

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

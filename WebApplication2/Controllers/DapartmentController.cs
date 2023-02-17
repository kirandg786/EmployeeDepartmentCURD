using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DapartmentController : Controller
    {
        // GET: Dapartment
        public ActionResult Index()
        {
            DBConnection db = new DBConnection();
            List<Dapartment> hjs = db.Dapartment.ToList();

            return View(hjs);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult SeveData(Dapartment dn)
        {
            DBConnection db = new DBConnection();
            db.Dapartment.Add(dn);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Edit(int Id)
        {
            DBConnection db = new DBConnection();
            Dapartment dn = db.Dapartment.Where(x => x.DapartmentId == Id).FirstOrDefault();
            return View(dn);
        }
        public ActionResult UpdateData(Dapartment dn)
        {
            DBConnection db = new DBConnection();
            Dapartment obj = db.Dapartment.Where(x => x.DapartmentId == dn.DapartmentId).FirstOrDefault();


            obj.Name = dn.Name;
            db.Dapartment.Attach(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Remove(int dn)
        {
            DBConnection db = new DBConnection();
            Dapartment obj = db.Dapartment.Where(x => x.DapartmentId == dn).FirstOrDefault();
            db.Dapartment.Remove(obj);
            db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();


            return RedirectToAction("Index");

        }
    }
}
        
    

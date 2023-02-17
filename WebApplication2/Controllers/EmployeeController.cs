using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.VM;

namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult List()
        {
            DBConnection df = new DBConnection();
            //   List<Employee> gfs = df.Employee.ToList();

            var fgs = (from e in df.Employee
                       join d in df.Dapartment on e.DapartmentId equals d.DapartmentId
                       select new EmployeeVM { 
                         EmployeeId = e.EmployeeId,
                         Name = e.Name,
                         Adderss = e.Adderss,
                         DapartmentId = e.DapartmentId,
                         DapartmentName = d.Name
                       }).ToList();
            return View(fgs);
        }
        public ActionResult Add()
        {
            DBConnection df = new DBConnection();
            List<Dapartment> Ged = df.Dapartment.ToList();
            ViewBag.Ged = new SelectList(Ged, "DapartmentId", "Name");
            return View();
        }
        public ActionResult SeveData(Employee model)
        {
            if (ModelState.IsValid == false)
            {
                return View("Add", model);
            }
            else
            {
                DBConnection df = new DBConnection();
                List<Dapartment> Ged = df.Dapartment.ToList();
                ViewBag.Ged = new SelectList(Ged, "DapartmentId", "Name");

                df.Employee.Add(model);
                df.SaveChanges();

                return RedirectToAction("List");
            }

        }
        public ActionResult Edit(int Id)
        {
            DBConnection df = new DBConnection();
            List<Dapartment> Ged = df.Dapartment.ToList();
            ViewBag.Ged = new SelectList(Ged, "DapartmentId", "Name");

            Employee hd = df.Employee.Where(x => x.EmployeeId == Id).FirstOrDefault();

            return View(hd);
        }
        public ActionResult UpdateData(Employee model)
        {
            DBConnection df = new DBConnection();
            List<Dapartment> Ged = df.Dapartment.ToList();
            ViewBag.Ged = new SelectList(Ged, "DapartmentId", "Name");

            if (ModelState.IsValid == false)
            {
                return View("Edit", model);
            }
            else
            {

                Employee Obj = df.Employee.Where(x => x.EmployeeId == model.EmployeeId).FirstOrDefault();


                Obj.Name = model.Name;
                Obj.Adderss = model.Adderss;
                Obj.DapartmentId = model.DapartmentId;
                df.Employee.Attach(Obj);
                df.Entry(Obj).State = System.Data.Entity.EntityState.Modified;
                df.SaveChanges();
                return RedirectToAction("List");
            }

            }
            public ActionResult Remove(int Id)
            {
                DBConnection db = new DBConnection();
                Employee obj = db.Employee.Where(x => x.EmployeeId == Id).FirstOrDefault();
                db.Employee.Remove(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();


                return RedirectToAction("List");

            }

        }
    }

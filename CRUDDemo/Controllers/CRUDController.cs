using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace CRUDDemo.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult create()
        {
            return View(new mstEmployee());
        }

        [HttpPost]    //Specify the type of attribute i.e. it will add the record to the database
        public ActionResult create(mstEmployee model)
        {
            using(var context = new FishEntities()) //To open a connection to the database
            {
                context.mstEmployees.Add(model); // Add data to the particular table
                context.SaveChanges(); // save the changes to the that are made
            }
            string message = "Created the record successfully";
            ViewBag.Message = message;     // To display the message on the screen after the record is created successfully
            return View(new mstEmployee()); // write @Viewbag.Message in the created view at the place where you want to display the message
        }

        [HttpGet] // Set the attribute to Read
        public ActionResult Read(string employeeName, string sortOrder)
        {
            ViewData["CurrentFilter"] = employeeName;
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            using (var context = new FishEntities())
            {
                var data = context.mstEmployees.ToList(); // Return the list of data from the database
                
                if (!String.IsNullOrEmpty(employeeName))
                {
                    data = data.Where(x=> x.EmployeeName.ToLower().Contains(employeeName.ToLower())).ToList();
                    return View(data);
                }
                else
                {
                    return View(data);
                }
            }
        }

        public ActionResult Update(int Id) // To fill data in the form to enable easy editing
        {
            using(var context = new FishEntities())
            {
                var data = context.mstEmployees.Where(x => x.Id == Id).SingleOrDefault();
                return View(data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // To specify that this will be invoked when post method is called
        public ActionResult Update(int Id, mstEmployee model)
        {
            using(var context = new FishEntities())
            {
                var data = context.mstEmployees.FirstOrDefault(x => x.Id == Id); // Use of lambda expression to access particular record from a database
                if (data != null) // Checking if any such record exist 
                {
                    data.NIK = model.NIK;
                    data.EmployeeName = model.EmployeeName;
                    data.EmployeeAddress = model.EmployeeAddress;
                    data.MarriedStatus = model.MarriedStatus;
                    data.CreatedBy = "Admin";
                    data.CreatedOn = DateTime.Now;
                    context.SaveChanges();
                    return RedirectToAction("Read"); // It will redirect to the Read method
                }
                else
                    return View(new mstEmployee());
            }
        }

        public ActionResult Delete()
        {
            return View(new mstEmployee());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            using(var context = new FishEntities())
            {
                var data = context.mstEmployees.FirstOrDefault(x => x.Id == Id);
                if (data != null)
                {
                    context.mstEmployees.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                    return View(new mstEmployee());
            }
        }
    }
}

// Just a small change
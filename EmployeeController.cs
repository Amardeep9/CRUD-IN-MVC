﻿using MVC_crud_Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_crud_Employee.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        // GET: /<controller>/
        public ActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = objemployee.GetAllEmployees().ToList();

            return View(lstEmployee);
        }




        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                objemployee.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }




        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult("Not Found");
            }
            Employee employee = objemployee.GetEmployeeData(id);

            if (employee == null)
            {
                return new HttpNotFoundResult("Not Found");
            }
            return View(employee);
        }

        [HttpPost]// submit operation
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind]Employee employee)
        {
            if (id != employee.ID)
            {
                return new HttpNotFoundResult("Not Found");
            }
            if (ModelState.IsValid)
            {
                objemployee.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }





        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult("Not Found");
            }
            Employee employee = objemployee.GetEmployeeData(id);

            if (employee == null)
            {
                return new HttpNotFoundResult("Not Found");
            }
            return View(employee);
        }



        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult("Not Found");
            }
            Employee employee = objemployee.GetEmployeeData(id);

            if (employee == null)
            {
                return new HttpNotFoundResult("Not Found");
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            objemployee.DeleteEmployee(id);
            return RedirectToAction("Index");
        }



    }
}
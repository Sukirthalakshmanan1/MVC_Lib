using Microsoft.Ajax.Utilities;
using MVC_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Lib.Controllers
{
    public class LibController : Controller
    {
        // GET: Lib
        static List<LibMember> custList = new List<LibMember>();
        static LibController()
        {
            custList.Add(new LibMember { Member_Id=1,Member_Name="Suki" });

           // ViewBag.customers = custList;
        }
        public ActionResult Index()
        {


            ViewBag.customers = custList;
            return View(custList);


        }
        public ActionResult Index1()
        {
            List<Book> custList = new List<Book>();
            custList.Add(new Book{Book_Id=1,Book_Name="Harry potter",Cost=1000});

            ViewData["mycustList"] = custList;

            // ViewBag.customers = custList;
            return View();
           // return View(custList);
        }
        public ActionResult PassData()
        {
            List<IssueBook> custList = new List<IssueBook>();
            custList.Add(new IssueBook { Issue_Id=11,Member_Id=1,Issuedate =new DateTime(2022, 01, 04) ,returndate = new DateTime(2022, 07, 04) });

            TempData["mycustdata"] = custList;
            return RedirectToAction("GetList");
        }

        public ActionResult GetList()
        {
            //ViewBag.mybag = TempData["mycustdata"];
            TempData["mybag"] = TempData["mycustdata"];

            return View();
        }

        public ActionResult Details(int id)
        {
            LibMember foundData = custList.Find(customer => customer.Member_Id == id);
            return View(foundData);
        }
        public ActionResult AddOrderDetails(int id)
        {
           LibMember foundData = custList.Find(customer => customer.Member_Id== id);
            return RedirectToAction("NowEditOrderDetails", new { id = foundData.Member_Id});
        }



        public ActionResult Delete(int id)
        {
            LibMember foundData = custList.Find(customer => customer.Member_Id == id);
            return View(foundData);
        }

        [HttpPost]
        public ActionResult Delete(int id, LibMember cust)
        {
            LibMember foundData = custList.Find(customer => customer.Member_Id == id);
            custList.Remove(foundData);
            // return View(foundData);
            return RedirectToAction("Index");

        }






        public ActionResult NowEditOrderDetails(int id)
        {
           LibMember foundData = custList.Find(customer => customer.Member_Id == id);


            return View(foundData);
        }

        [HttpPost]

        public ActionResult NowEditOrderDetails(int id, LibMember m)
        {
            LibMember foundData = custList.Find(customer => customer.Member_Id == id);
            custList.Remove(foundData);
            custList.Add(m);
            return RedirectToAction("Index");
        }


        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(LibMember model)
        {
            custList.Add(model);
            return RedirectToAction("Index");
        }
    }
}
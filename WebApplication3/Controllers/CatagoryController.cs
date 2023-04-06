using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Net;
using WebApplication3.Repository;
using PagedList;
using PagedList.Mvc;

namespace WebApplication3.Controllers
{
    public class CatagoryController : Controller
    {
       // private ICatagoryRepo repo { get; set; }

        private CatagoryRepo repo = new CatagoryRepo();
        public CatagoryController()
        {

        }
      
        // This method will used to Get total data Of Catagory Table
        public ActionResult Index(int? i)
        {
            try
            {
                var data = repo.GetCatagory().ToList().ToPagedList(i ?? 1, 2);
                return View(data);
            }
            catch
            {
                return View();
            }
           
        }
        //This method will used to get Details about Catagory table Using an Id 
        public ActionResult Details(int? id)
        {
          
            var cdata = repo.GetCatagoryById(id);
            
            return View(cdata);

        }
        //This method will used to insert data into Catagory Table
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include ="CId,CatagoryName")] CatagoryFirst catagory)
        {
            if(ModelState.IsValid)
            {
               
                if(repo.AddCatagory(catagory))
                {
                    ViewBag.Message = "Catagory Details Added Successfully";
                    return RedirectToAction("Index");
                }
            }
            return View();

        }
        //This method will used to Update the data of  catagory table by using Id
        public ActionResult Edit(int? id)
        {
           
            var cdata = repo.GetCatagoryById(id);
           
            return View(cdata);

        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "CId,CatagoryName")] CatagoryFirst catagory)
        {
            if(ModelState.IsValid)
            {
               // var cdata = repo.UpdateCatagory(catagory);
                 repo.UpdateCatagory(catagory);
                return RedirectToAction("Indext");
            }
            return View();
        }

        //This method will used to Delete The catagory table data by using an Id
        public ActionResult Delete(int? id)
        {
           
            repo.GetCatagoryById(id);

            
            return View();

        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed([Bind(Include = "CId,CatagoryName")] int? id)
        {
            if (id != null)
            {
              

                if (repo.DeleteCatagory(id))
                {
                    ViewBag.AlertMsg = "Catagory details deleted successfully";
                }
                else
                    ViewBag.AlertMsg = "Catagory details Not deleted successfully";


            }
            return RedirectToAction("Index");

        }


    }
}
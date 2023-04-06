using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Repository;
using PagedList;
using PagedList.Mvc;

namespace WebApplication3.Controllers
{
    public class ProductFirstsController : Controller
    {
        ProductRepo repo = new ProductRepo();


        public ActionResult Index(int? i)
        {

            var data = repo.GetProductData().ToList().ToPagedList(i ?? 1, 2);
            return View(data);
        }


        public ActionResult Details(int? id)
        {
            CatagoryRepo catagoryRepo = new CatagoryRepo();

            ViewBag.CatagoryFirst = catagoryRepo.GetCatagory();
            ProductFirst productFirst = repo.GetProductById(id);
           
            return View(productFirst);
        }

       
        public ActionResult Create()
        {
            CatagoryRepo catagoryRepo = new CatagoryRepo();
            ViewBag.CatagoryFirst = new SelectList(catagoryRepo.GetCatagory(), "CId", "CatagoryName");
            return View();
        }

        
        [HttpPost]
        
        public ActionResult Create( ProductFirst productFirst)
        {
            if (ModelState.IsValid)
            {

                repo.AddProduct(productFirst);
                return RedirectToAction("Index");
            }

            return View(productFirst);
        }

        
        public ActionResult Edit(int? id)
        {
            CatagoryRepo catagoryRepo = new CatagoryRepo();
            ViewBag.CatagoryFirst = new SelectList(catagoryRepo.GetCatagory(), "CId", "CatagoryName");
            ProductFirst productFirst = repo.GetProductById(id);
           
            return View(productFirst);
        }

       
        [HttpPost]
        
        public ActionResult Edit( ProductFirst productFirst)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateProduct(productFirst);
                return RedirectToAction("Index");
            }
            return View(productFirst);
        }

        
        public ActionResult Delete(int? id)
        {

           repo.GetProductById(id);
           
            return View();
        }

      
        [HttpPost, ActionName("Delete")]
      
        public ActionResult DeleteConfirmed(int id)
        {
            repo.DeleteProduct(id);
            return RedirectToAction("Index");
        }

       
    }
}

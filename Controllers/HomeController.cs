using Recepboyvat.ECommerceMVCWeb.Entity;
using Recepboyvat.ECommerceMVCWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recepboyvat.ECommerceMVCWeb.Controllers
{
    public class HomeController : Controller
    {

        DataContext _context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products.Where(i => i.IsHome && i.IsApproved)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name=i.Name,
                    Description=i.Description.Length>50?i.Description.Substring(0,47)+"...":i.Description,
                    Price=i.Price,
                    Stock=i.Stock,
                    CombinationNumber=i.CombinationNumber,
                    Image=i.Image,
                    CategoryId=i.CategoryId
 
                }).ToList();



            return View(urunler);
        }
        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i=>i.Id==id).FirstOrDefault());
        }





        public ActionResult List(int? id)
        {
            var urunler = _context.Products.Where(i => i.IsApproved)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    CombinationNumber = i.CombinationNumber,
                    Image = i.Image ?? "1.jpg",
                    CategoryId = i.CategoryId

                }).AsQueryable();

            if(id!=null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler.ToList());
        }






        public ActionResult Kombinler()
        {
            var kombinler = _context.Products.Where(i => i.CombinationNumber != 0)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    CombinationNumber = i.CombinationNumber,
                    Image = i.Image ?? "1.jpg",
                    CategoryId = i.CategoryId
                }).ToList();




               return View(kombinler);
             
           
        }

        public PartialViewResult GetCategories(){


            return PartialView(_context.Categories.ToList());

        }
        public ActionResult hakkimizda()
        {
            return View();
        }
      
    }
}
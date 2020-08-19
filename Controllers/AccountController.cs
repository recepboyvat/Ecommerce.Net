﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Recepboyvat.ECommerceMVCWeb.Entity;
using Recepboyvat.ECommerceMVCWeb.Identity;
using Recepboyvat.ECommerceMVCWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recepboyvat.ECommerceMVCWeb.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
           var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);

        }
        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.UserName == username)
                .Select(i => new UserOrderModel()
                {
                    Id=i.Id,
                    OrderNumber=i.OrderNumber,
                    OrderDate=i.OrderDate,
                    OrderState=i.OrderState,
                    Total=i.Total

                }).OrderByDescending(i=>i.OrderDate).ToList();

            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Mahalle = i.Mahalle,
                    PostaKodu = i.PostaKodu,
                    OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                    {
                        ProductId=a.ProductId,
                         ProductName=a.Product.Name,
                         Image=a.Product.Image,
                         Quantity=a.Quantity,
                         Price=a.Price

                    }).ToList()




                }).FirstOrDefault();


            return View(entity);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                IdentityResult result=UserManager.Create(user, model.Password);

                if(result.Succeeded)
                {
                    //kullanici olustu ve kullaniciya rol atanabilir

                    if(RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");

                   
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanici olusturma hatasi");
                }



            }
           


            return View(model);
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login islemleri

                var user=UserManager.Find(model.UserName, model.Password);
                if(user!=null)
                {
                    //varolan kullaniciyi sisteme dahil et
                    //ApplicationCookie olusturup sisteme saliyoruz

                    var authManager = HttpContext.GetOwinContext().Authentication;

                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");

                    var authProperties = new AuthenticationProperties();

                    authProperties.IsPersistent= model.RememberMe;

                    authManager.SignIn(authProperties,identityclaims);

                    if(!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Boyle bir kullanici yok");
                }


            }


            return View(model);
        }


        public ActionResult Logout()
        {

            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();



            return RedirectToAction("Index", "Home");
        }



    }
}
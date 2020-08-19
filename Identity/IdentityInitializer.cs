using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Recepboyvat.ECommerceMVCWeb.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //roller
            if(!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager =new  RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name="admin",Description="Admin Rolu"};
                manager.Create(role);



            }


            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "user", Description = "User Rolu" };
                manager.Create(role);



            }

            if (!context.Roles.Any(i => i.Name == "recepboyvat"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name="Recep",SurName="Boyvat",UserName="recepboyvat",Email="rcpbyvt@gmail.com"};
                
                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");

            }
            if (!context.Roles.Any(i => i.Name == "seymaboyvat"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "Seyma", SurName = "Boyvat", UserName = "seymaboyvat", Email = "symbyvt@gmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");

            }



            base.Seed(context);
        }
    }
}
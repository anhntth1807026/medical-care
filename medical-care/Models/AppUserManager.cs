using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using medical_care.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace medical_care.Models
{
    public class AppUserManager : UserManager<Employee>
    {
        public AppUserManager(IUserStore<Employee> store) : base(store)
        {
        }
        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(
                new UserStore<Employee>(context.Get<MyDbContext>()));

            // optionally configure your manager

            return manager;
        }
    }
}
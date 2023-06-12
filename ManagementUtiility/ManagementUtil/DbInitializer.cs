using ManagemeantModel;
using ManagementRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementUtil
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private AppDBContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, AppDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if(_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate();
                }
                
            }
            catch(Exception e)
            {
                throw;
            }

            if(!_roleManager.RoleExistsAsync(WebSiteRoles.Web_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Web_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Web_Public)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Web_User)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new AppUser
                {
                    UserName = "Dipesh",
                    Email="Hello@gmail.com"
                },"Dipesh@123").GetAwaiter().GetResult() ;

               var AppUser= _context.AppUsers.FirstOrDefault(x => x.Email== "Hello@gmail.com");

                if(AppUser!=null)
                {
                    _userManager.AddToRoleAsync(AppUser,WebSiteRoles.Web_Admin).GetAwaiter().GetResult();
                }
            }
        }
    }
}

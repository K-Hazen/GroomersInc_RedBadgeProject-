using Groonmers.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedBadgeProject.WebMVC.Startup))]
namespace RedBadgeProject.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole> (new RoleStore<IdentityRole>(context));

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "bossPerson";
                user.Email = "bossPerson@test.com";

                string userPWD = "Password1!";

                var checkUser = UserManager.Create(user, userPWD);

                if (checkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            //if (!roleManager.RoleExists("Employee"))
            //{
            //    var role = new IdentityRole();
            //    role.Name = "Employee";
            //    roleManager.Create(role);
            //}

            //if (!roleManager.RoleExists("Customer"))
            //{
            //    var role = new IdentityRole();
            //    role.Name = "Customer";
            //    roleManager.Create(role);
            //}
        }


    }
}

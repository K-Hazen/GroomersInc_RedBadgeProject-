using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeProject.WebMVC.CustomFilters
{
    public class AuthLogAttribute : AuthorizeAttribute
    {
        public AuthLogAttribute() 
        {
            View = "AuthorizeFailed";
        }

        public string View { get; set; }

        //Check for Authorization
        //<param name = "filterContext>

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext); 
        }

        //method to check whether user is authorized or not 
        //If yes continue to perform the action, else redirect to error page

        private void IsUserAuthorized(AuthorizationContext filterContext)
        {
            //if the result returns null then the user is authorized
            if (filterContext.Result == null)
                return;

            //if the user in not authorized then navigate to auth failed view
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var vr = new ViewResult();
                vr.ViewName = View;

                //ViewDataDictionary dict = new ViewDataDictionary();
                //dict.Add("Message", "You are not Authorized to enter. Return from whence you came!");

                //vr.ViewData = dict;

                var result = vr;

                filterContext.Result = result; 
            }
        }

    }
}
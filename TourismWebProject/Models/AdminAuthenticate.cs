using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourismWebProject.Models
{
    public class AdminAuthenticate : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["adminLog"] == null)
            {
                filterContext.Result = new RedirectResult("/Admin/Account/Login");
            }
        }
    }
}
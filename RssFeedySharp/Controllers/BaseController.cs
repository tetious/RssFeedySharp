using System.Web.Mvc;
using RssFeedySharp.Models;

namespace RssFeedySharp.Controllers
{
    public class BaseController : Controller
    {
        protected UserAccount CurrentUser
        {
            get { return Session["CurrentUser"] as UserAccount; }
            set { Session["CurrentUser"] = value; }
        }
    }
}
using System.Web.Mvc;
using System.Web.Providers.Entities;
using RssFeedySharp.Models;

namespace RssFeedySharp.Controllers
{
    public class AccountController : BaseController
    {
        // this is just quick, dirty and ugly as I want to move on to other parts of the stuffs
        public ViewResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            if (CurrentUser == null)
                return RedirectToAction("Login");

            return View(CurrentUser);
        }

        public RedirectToRouteResult DeleteSession()
        {
            CurrentUser = null;
            return RedirectToAction("Login");
        }

        [ValidateAntiForgeryToken]
        public RedirectToRouteResult CreateSession(string username)
        {
            using (var ctx = new FeedyContext())
                CurrentUser = ctx.UserAccounts.Find(username);

            return RedirectToAction("Index");
        }
    }
}
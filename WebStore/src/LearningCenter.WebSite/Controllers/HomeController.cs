using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningCenter.Business;
using LearningCenter.WebSite.Models;


namespace LearningCenter.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryManager categoryManager;
        private readonly IUserManager userManager;
        //private readonly IShoppingCartManager shoppingCartManager;

        public HomeController(ICategoryManager categoryManager, IUserManager userManager)
        {
            this.categoryManager = categoryManager;
            this.userManager = userManager;
            //this.shoppingCartManager = shoppingCartManager;
        }

        public ActionResult Index()
        {
            var categories = categoryManager.Categories
                                            .Select(t => new LearningCenter.WebSite.Models.CategoryModel(t.Id, t.Name, t.Description, t.Price))
                                            .ToArray();
            var model = new IndexModel { Categories = categories };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private readonly IProductManager productManager;
        public HomeController(ICategoryManager categoryManager, IProductManager productManager)
        {
            this.categoryManager = categoryManager;
            this.productManager = productManager;
        }

        public ActionResult Classes()
        {
            var categories = categoryManager.Categories
                                .Select(t => new LearningCenter.WebSite.Models.CategoryModel(t.Id, t.Name, t.Description, t.Price))
                                .ToArray();
            var model = new IndexModel { Categories = categories };
            return View(model);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.LogIn(loginModel.UserName, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new LearningCenter.WebSite.Models.UserModel { Id = user.Id, Name = user.Name };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginModel.UserName, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }

            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            Session["User"] = null;
            System.Web.Security.FormsAuthentication.SignOut();

            return Redirect("~/");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Register(registerModel.Email, registerModel.Password);

                return Redirect("~/");
            }

            return View();
        }

        //[Authorize]
        //public ActionResult AddToCart(int id)
        //{
        //    var user = (LearningCenter.WebSite.Models.UserModel)Session["User"];
        //    var item = shoppingCartManager.Add(user.Id, id, 1);
        //    var items = shoppingCartManager.GetAll(user.Id)
        //        .Select(t => new LearningCenter.WebSite.Models.ShoppingCartItem
        //        {
        //            UserId = t.UserId,
        //            ProductId = t.ProductId,
        //            Quantity = t.Quantity
        //        })
        //        .ToArray();
        //    return View(items);
        //}
    }
}
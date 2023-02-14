using BirthdayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            ViewBag.Message = DateTime.Now.Hour > 12 ? "Good Afternoon" : "Good Morning";
            return View();
        }
        [HttpGet]
        public ActionResult ResponseForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResponseForm(UserResponse response)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(response);
                return View("Thanks", response);
            }
            return View();
        }

        public ViewResult ListResponse()
        {
            //return View(Repository.Responses.Where(i => i.WillAttend == true));
            return View(Repository.Responses);
        }
        public ViewResult Details(int id)
        {
            return View(Repository.Responses.Find(i => i.Id == id));
        }
        [HttpGet]
        public ViewResult Update(int id)
        {
            return View(Repository.Responses.Find(i => i.Id == id));
        }

        [HttpPost]
        public ViewResult Update(UserResponse response)
        {
            if (ModelState.IsValid)
            {
                Repository.Update(response);
                ViewBag.Success = "Your data has been saved";
                return View();
            }
            return View();

        }
        [HttpGet]
        public ViewResult Delete(int id)
        {
            return View(Repository.Responses.Find(i=>i.Id==id));
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("ListResponse");
        }
    }
}
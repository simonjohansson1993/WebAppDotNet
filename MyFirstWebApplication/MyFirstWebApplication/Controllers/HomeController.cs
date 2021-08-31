using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using environment_crime.Infrastructure;
using environment_crime.Models;

namespace MyFirstWebApplication.controllers {
  public class HomeController : Controller {
    public ViewResult Index() {
     //show data from previous crime report
      var myReport = HttpContext.Session.GetJson<Errand>("NewErrand");
      if (myReport == null) {
        return View();
      }
      else {
        return View(myReport);
      }

    }
    public ViewResult Login() {
      ViewBag.Title = "login";
      return View();
    }

    public ViewResult NewCrime() {
      ViewBag.Title = "login";
      return View();
    }


  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using environment_crime.Models;
using System.Net;
using environment_crime.Infrastructure;

namespace MyFirstWebApplication.Controllers {
  public class CitizenController : Controller {
    private InterfaceRepository repository;
    public CitizenController(InterfaceRepository repo) {
      repository = repo;
    }
    public ViewResult Contact() {
      
      return View();
    }
    public ViewResult Faq() {
     
      return View();
    }
    public ViewResult Services() {
      
      return View();
    }
    
    public ViewResult Thanks() {
      
      //Using sessions to display already filled in information.
      // Creates and saves a new errand with user input
      Errand errand = new Errand();
      Errand newErrand = HttpContext.Session.GetJson<Errand>("NewErrand");
      errand.InformerName = newErrand.InformerName;
      errand.TypeOfCrime = newErrand.TypeOfCrime;
      errand.Place = newErrand.Place;
      errand.DateOfObservation = newErrand.DateOfObservation;
      errand.InformerPhone = newErrand.InformerPhone;
      errand.Observation = newErrand.Observation;
      errand.StatusId = "S_A";
      Sequence sequence = repository.getSequenceDetail(1);
      errand.RefNumber = "2020-45-" + sequence.CurrentValue;
      repository.SaveErrand(errand);

      sequence.CurrentValue++;
      repository.SaveSequence(sequence);

      HttpContext.Session.Remove("NewErrand");
      
      return View(errand);
    }
    [HttpPost]
    public ViewResult Validate(Errand errand) {
      HttpContext.Session.SetJson("NewErrand",errand);

      return View(errand);
    }
  }
  
}

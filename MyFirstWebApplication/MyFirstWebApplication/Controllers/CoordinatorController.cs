using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using environment_crime.Models;
using Microsoft.AspNetCore.Mvc;
using environment_crime.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace MyFirstWebApplication.Controllers {
  [Authorize(Roles = "Coordinator")]
  public class CoordinatorController : Controller {

    private InterfaceRepository repository;
    private IHttpContextAccessor contextAcc;
    public CoordinatorController(InterfaceRepository repo, IHttpContextAccessor cont) {
      repository = repo;
      contextAcc = cont;
    }
    public ViewResult CrimeCoordinator(int id) {
      ViewBag.ID = id;
      IQueryable<Department> departments = repository.Departments.Where(Department => Department.DepartmentName != "Småstads kommun");
      ViewBag.ListOfDepartments = departments;
     
      return View();
    }
    public ViewResult ReportCrime() {
      var myReport = HttpContext.Session.GetJson<Errand>("NewErrand");
      if (myReport == null) {
        return View();
      }
      else {
        return View(myReport);
      }
      
    }
    
    public ViewResult StartCoordinator() {
      IQueryable<ErrandStatus> errandStatuses = repository.ErrandStatuses.Where(ErrandStatus => ErrandStatus.StatusId !=null);
      ViewBag.ListOfErrandStatuses = errandStatuses;
      ViewBag.Title = "Contact: Crime Report";
      return View(repository);
    }
    public ViewResult UpdateErrand(int id, Department department) {
      Errand errand = repository.getErrandDetail2(id);

      //Be sure that a DepartmentId has been selected
      if (department.DepartmentId != "Välj") {
        errand.DepartmentId = department.DepartmentId;
        repository.SaveErrand(errand);
      }

      ViewBag.ID = id;
      IQueryable<Department> departments = repository.Departments.Where(Department => Department.DepartmentName != "Småstads kommun");
      ViewBag.ListOfDepartments = departments;
      
      return View("CrimeCoordinator");
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
      HttpContext.Session.SetJson("NewErrand", errand);
      return View(errand);
    }
   
  }
}

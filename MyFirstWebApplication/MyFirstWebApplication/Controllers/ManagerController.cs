using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using environment_crime.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyFirstWebApplication.Controllers {
  public class ManagerController : Controller {
   

    private InterfaceRepository repository;
    private IHttpContextAccessor contextAcc;
    public ManagerController(InterfaceRepository repo, IHttpContextAccessor cont) {
      repository = repo;
      contextAcc = cont;
    }
   
    public ViewResult CrimeManager(int id) {
      ViewBag.ID = id;
      var userName = contextAcc.HttpContext.User.Identity.Name;
      Employee employee = repository.getEmployeeDetail(userName);
      IQueryable<Employee> employees = repository.Employees.Where(Employee => Employee.RoleTitle == "Investigator").Where(Employee => Employee.DepartmentId == employee.DepartmentId); 
      ViewBag.ListOfEmployees = employees;
      return View();
    }
    public ViewResult StartManager() {
      
      var userName = contextAcc.HttpContext.User.Identity.Name;
      Employee employee = repository.getEmployeeDetail(userName);
      IQueryable<Errand> errands = repository.Errands.Where(Errand => Errand.DepartmentId == employee.DepartmentId);
      IQueryable<Employee> employees = repository.Employees.Where(Employee => Employee.RoleTitle == "Investigator").Where(Employee => Employee.DepartmentId == employee.DepartmentId); 
      
      ViewBag.ListOfInvestigators = employees;
      
      ViewBag.ListOfErrands = errands;
      return View(repository);
    }
    public ViewResult UpdateErrand(int id, bool noAction, string reason, string investigatorID) {
      Errand errandToChange = repository.getErrandDetail2(id);

      //Employee employeeToChange = repository.getEmployeeDetail(investigatorID);
      //display informername on the errand page.
      //string informer = employeeToChange.EmployeeName;

      
      if (noAction == true) {
        errandToChange.StatusId = "S_B";
        errandToChange.InvestigatorInfo = reason;
        errandToChange.EmployeeId = null;
        repository.SaveErrand(errandToChange);
      }
      else {
        errandToChange.EmployeeId = investigatorID;
        errandToChange.StatusId = "S_A";
        
        repository.SaveErrand(errandToChange);
      }

      ViewBag.ID = errandToChange.ErrandId;
      

      IQueryable<Employee> employees = repository.Employees.Where(Employee => Employee.RoleTitle == "Investigator");
      ViewBag.ListOfEmployees = employees;


      return View("CrimeManager");
    }

  }
}

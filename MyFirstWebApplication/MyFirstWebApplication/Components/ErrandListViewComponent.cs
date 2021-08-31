using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using environment_crime.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace environment_crime.Components {
  public class ErrandListViewComponent : ViewComponent {
    private InterfaceRepository repository;
    private IHttpContextAccessor contextAcc;
    public ErrandListViewComponent(InterfaceRepository repo, IHttpContextAccessor cont) {
    repository = repo;
      contextAcc = cont;
    }
  public async Task<IViewComponentResult> InvokeAsync() {
     
      //Create a list of myErrands to show for coordinators
      var errandDetail = repository.getMyErrandList();
      var userName = contextAcc.HttpContext.User.Identity.Name;
      Employee employee = repository.getEmployeeDetail(userName);
      Department departmentDetail = repository.getDepartmentDetail(employee.DepartmentId);
      ViewBag.ListOfMyErrands = errandDetail;

      //Create a custom list of errands for logged in Managers
      List<MyErrand> MyErrandList = new List<MyErrand>();

      foreach (MyErrand errand in errandDetail) {
        if (errand.DepartmentName == departmentDetail.DepartmentName) {
          MyErrandList.Add(errand);
        }
      }

      ViewBag.ListOfMyErrandsSameDepartment = MyErrandList;

      //Create a custom list of errands for logged in Investigators
      List<MyErrand> myErrandForInvestigators = new List<MyErrand>();
      
        foreach (MyErrand errand in errandDetail) {
        if (errand.EmployeeName == employee.EmployeeName) {
          myErrandForInvestigators.Add(errand);
        }
      }
      ViewBag.ListOfInvestigatorErrands = myErrandForInvestigators;

      return View();
    }
  }
}



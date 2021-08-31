using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using environment_crime.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MyFirstWebApplication.Controllers {
  public class InvestigatorController : Controller {

    private InterfaceRepository repository;
    private IWebHostEnvironment environment;
    private IHttpContextAccessor contextAcc;
    public InvestigatorController(InterfaceRepository repo, IHttpContextAccessor cont, IWebHostEnvironment env) {
      repository = repo;
      contextAcc = cont;
      environment = env;

    }
    public ViewResult CrimeInvestigator(int id) {

      ViewBag.ID = id;

      IQueryable<ErrandStatus> errandStatuses = repository.ErrandStatuses.Where(ErrandStatus => ErrandStatus.StatusId == "S_C" || ErrandStatus.StatusId == "S_D");
      ViewBag.ListOfErrandStatuses = errandStatuses;
      return View();
    }
    public ViewResult StartInvestigator() {
      var userName = contextAcc.HttpContext.User.Identity.Name;
      Employee employee = repository.getEmployeeDetail(userName);
      IQueryable<Errand> errands = repository.Errands.Where(Errand => Errand.InformerName == employee.EmployeeName);
      ViewBag.ListOfErrands = errands;
      return View(repository);
    }

    public async Task<IActionResult> UpdateErrandStatus(int id, string statusId, string information, string events, IFormFile loadSample, IFormFile loadImage) {
      //No updates in DB will happen when clicking on form button if we havent chosed påbörjad/klar. 
      if (statusId=="S_C" || statusId == "S_D") {  
      Errand errandToChange = repository.getErrandDetail2(id);
      string tempEvents = errandToChange.InvestigatorAction;
      string tempInformation = errandToChange.InvestigatorInfo;

      if (events != null) {
        
        errandToChange.InvestigatorAction = tempEvents + " " +  events;
      }
      else {
        errandToChange.InvestigatorAction = events;
      }

      if (information != null) {
        errandToChange.InvestigatorInfo = tempInformation + " " + information;
      }
      else {
        errandToChange.InvestigatorInfo = information;
      }

      errandToChange.StatusId = statusId;
      repository.SaveErrand(errandToChange);
      }


      if (loadSample != null) {
        //temporär sökväg
        var tempPath = Path.GetTempFileName();
        if (loadSample.Length > 0) {
          using (var stream = new FileStream(tempPath, FileMode.Create)) {
            await loadSample.CopyToAsync(stream);
          }
        }
        //unique filename with Guid
        string uniqueFileName = Guid.NewGuid().ToString() + "_" + loadSample.FileName;

        //get fileName
        var path = Path.Combine(environment.WebRootPath, "samples", uniqueFileName);

        //save on server instead of client

        System.IO.File.Move(tempPath, path);

        ViewBag.FileName = uniqueFileName;

        Sample sample = new Sample();
        sample.ErrandId = id;
        sample.SampleName = uniqueFileName;
        repository.SaveSample(sample);
      }

      if (loadImage != null) {
        var tempPathImage = Path.GetTempFileName();
        if (loadImage.Length > 0) {
          using (var stream = new FileStream(tempPathImage, FileMode.Create)) {
            await loadImage.CopyToAsync(stream);
          }
        }
        string uniqueImageName = Guid.NewGuid().ToString() + "_" + loadImage.FileName;
        //Create a new path        
        var imagePath = Path.Combine(environment.WebRootPath, "pictures", uniqueImageName);

        System.IO.File.Move(tempPathImage, imagePath);

        
        Picture picture = new Picture();
        picture.ErrandId = id;
        picture.PictureName = uniqueImageName;
        repository.SavePicture(picture);
      }

      ViewBag.ID = id;

      IQueryable<ErrandStatus> errandStatuses = repository.ErrandStatuses.Where(ErrandStatus => ErrandStatus.StatusId == "S_C"|| ErrandStatus.StatusId == "S_D");

      ViewBag.ListOfErrandStatuses = errandStatuses;
       
      return View("CrimeInvestigator");
    }
 }
}

  



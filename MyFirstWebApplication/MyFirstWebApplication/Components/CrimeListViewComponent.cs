using environment_crime.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace environment_crime.Components {
  public class CrimeListViewComponent : ViewComponent {
    private InterfaceRepository repository;
    public CrimeListViewComponent(InterfaceRepository repo) {
      repository = repo;
    }
    public async Task<IViewComponentResult> InvokeAsync(int id) {
      var errandDetail = await repository.getErrandDetail(id);



      //Create a list of Samples and Picture for a specific errand used in crime view
      List<Sample> listOfSamples = new List<Sample>();
      List<Picture> listOfPictures = new List<Picture>();
      foreach (Sample sample in errandDetail.Samples) {
        listOfSamples.Add(sample);
      }
      foreach (Picture picture in errandDetail.Pictures) {
        listOfPictures.Add(picture);
      }
      ViewBag.ListOfSamples = listOfSamples;
      ViewBag.ListOfPictures = listOfPictures;


      return View(errandDetail);
    }
  }
}

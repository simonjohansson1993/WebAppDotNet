using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace environment_crime.Models {
  public class Errand {

    public int ErrandId { set; get; }

    
    public String RefNumber { set; get; }

    [Required(ErrorMessage ="du måste ange plats")]
    public String Place { set; get; }
    [Required(ErrorMessage = "du måste ange typ")]
    public String TypeOfCrime { set; get; }
    [Required(ErrorMessage = "du måste ange datum")]
    public DateTime DateOfObservation { set; get; }

    public String Observation { set; get; }
    public String InvestigatorInfo { set; get; }
    public String InvestigatorAction { set; get; }
    [Required(ErrorMessage = "du måste ange ditt namn")]
    public String InformerName { set; get; }
    

    [RegularExpression(@"^\d{2,4}-[0-9]{5,9}$",ErrorMessage ="Formatet är riktnummer-telefonnummer")]
    [Required(ErrorMessage = "du måste ange telefon nummer")]
    public String InformerPhone { set; get; }
    public String StatusId { set; get; }
    public String DepartmentId { set; get; }
    public String EmployeeId { set; get; }

    public ICollection<Sample> Samples { get; set; }

    public ICollection<Picture> Pictures { get; set; }
  }
}

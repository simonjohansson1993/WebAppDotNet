using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace environment_crime.Models {
  public class MyErrand {
    public DateTime DateOfObservation { set; get; }
    public int ErrandId { set; get; }
    public String RefNumber { set; get; }

    public String TypeOfCrime { set; get; }

    public String StatusName { set; get; }

    public String DepartmentName { set; get; }

    public String EmployeeName { set; get; }

    }
}

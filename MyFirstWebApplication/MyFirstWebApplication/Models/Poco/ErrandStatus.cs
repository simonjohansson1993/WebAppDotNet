using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace environment_crime.Models {
  public class ErrandStatus {
    [Key]
    public String StatusId { set; get; }
    public String StatusName { set; get; }

  }
}

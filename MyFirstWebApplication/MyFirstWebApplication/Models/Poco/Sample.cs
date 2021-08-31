using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace environment_crime.Models {
  public class Sample {
    public String SampleName{ set; get; }
    public int SampleId { set; get; }

    public int ErrandId { set; get; }
  }
}

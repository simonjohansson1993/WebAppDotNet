using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace environment_crime.Models {
  public class Sequence {
    public int Id { set; get; }
    public int CurrentValue { set; get; } //Löpnummer (år-45-200), (år,45,201) etc...
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace environment_crime.Models {
  public class Picture {

    public String PictureName { set; get; }
    public int PictureId { set; get; }

    public int ErrandId { set; get; }

  }
}

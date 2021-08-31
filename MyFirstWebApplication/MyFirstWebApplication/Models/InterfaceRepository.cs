using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace environment_crime.Models {
 public interface InterfaceRepository {
   
    IQueryable<Employee> Employees { get; }
    IQueryable<Errand> Errands { get; }
    IQueryable<ErrandStatus> ErrandStatuses { get; }
    IQueryable<Sequence> Sequences { get; }
    IQueryable<Department> Departments { get; }

    Task<Errand> getErrandDetail(int id);
    Employee getEmployeeDetail(string id);

    Errand getErrandDetail2(int id);
    ErrandStatus getErrandStatusDetail(string id);
    Department getDepartmentDetail(string id);
    Sequence getSequenceDetail(int id);

    //Create and update - if exist -> override
    void SaveErrand(Errand errand) {

    }
    void SaveSequence(Sequence sequence);

    void SaveSample(Sample sample);
    void SavePicture(Picture picture);

    IQueryable<MyErrand> getMyErrandList();
    //Delete
    Errand DeleteErrand(int errandId);
  }
}

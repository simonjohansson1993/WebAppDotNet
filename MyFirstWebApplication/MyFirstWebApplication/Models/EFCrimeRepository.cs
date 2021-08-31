using environment_crime.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace environment_crime.Models {
  public class EFCrimeRepository : InterfaceRepository {

    private ApplicationDbContext context;

    public EFCrimeRepository(ApplicationDbContext ctx) {
      context = ctx;
    }
    
    public IQueryable<Department> Departments => context.Departments;
    public IQueryable<Employee> Employees => context.Employees;
    public IQueryable<Errand> Errands => context.Errands.Include(e=>e.Samples).Include(e=>e.Pictures);
    public IQueryable<ErrandStatus> ErrandStatuses => context.ErrandStatuses;

    public IQueryable<Picture> Pictures => context.Pictures;
    public IQueryable<Sample> Samples => context.Samples;

    public IQueryable<Sequence> Sequences => context.Sequences;

    public Task<Errand> getErrandDetail(int id) {
      return Task.Run(() => {
        var errandDetail = Errands.Where(err => err.ErrandId == id).First();
        return errandDetail;
      });
    }

    public IQueryable<MyErrand> getMyErrandList() {

      var errandList = from err in Errands
                         join stat in ErrandStatuses on err.StatusId equals stat.StatusId
                         join dep in Departments on err.DepartmentId equals dep.DepartmentId
                         into departmentErrand
                         from deptE in departmentErrand.DefaultIfEmpty()
                         join em in Employees on err.EmployeeId equals em.EmployeeId
                         into employeeErrand
                         from empE in employeeErrand.DefaultIfEmpty()
                         orderby err.RefNumber descending
                         select new MyErrand {
                           DateOfObservation = err.DateOfObservation,
                           ErrandId = err.ErrandId,
                           RefNumber = err.RefNumber,
                           TypeOfCrime = err.TypeOfCrime,
                           StatusName = stat.StatusName,
                           DepartmentName = (err.DepartmentId == null ? "ej tillsatt" : deptE.DepartmentName),
                           EmployeeName = (err.EmployeeId == null ? "ej tillsatt" : empE.EmployeeName)
                         };
        return errandList;
    }

    public Sequence getSequenceDetail(int id) {
     
       Sequence sequenceDetail = Sequences.Where(se => se.Id == id).First();
        return sequenceDetail;

    }
    public Errand getErrandDetail2(int id) {

      Errand errandDetail = Errands.Where(err => err.ErrandId == id).First();
      return errandDetail;

    }

    public Employee getEmployeeDetail(string id) {
      Employee employeeDetail = Employees.Where(ed => ed.EmployeeId == id).First();
      return employeeDetail;
    }

    public ErrandStatus getErrandStatusDetail(string id) {
      ErrandStatus errandStatusDetail = ErrandStatuses.Where(es => es.StatusId == id).First();
      return errandStatusDetail;
    }

    public Sample getSampleDetail(int id) {

      Sample sampleDetail = Samples.Where(sd => sd.SampleId == id).First();
      return sampleDetail;

    }
    public Department getDepartmentDetail(string id) {
      Department departmentDetail = Departments.Where(dd => dd.DepartmentId == id).First();
      return departmentDetail;
    }


    //Create or update
    public void SaveErrand(Errand errand) {
      if (errand.ErrandId == 0) {
        context.Errands.Add(errand);
      }

      else {

        Errand dbEntry = context.Errands.FirstOrDefault(e => e.ErrandId == errand.ErrandId);
        if (dbEntry != null) {
         
          dbEntry.DepartmentId = errand.DepartmentId;


        }
        
      }
      context.SaveChanges();

    }
   

    public void SaveSequence(Sequence sequence) {
      if (sequence.Id == 0) {
        context.Sequences.Add(sequence);
      }
      else {

        Sequence dbEntry = context.Sequences.FirstOrDefault(s => s.Id == sequence.Id);
        if (dbEntry != null) {
          dbEntry.CurrentValue = sequence.CurrentValue;
          dbEntry.Id = sequence.Id;
           }
      }
      context.SaveChanges();
    }

    //Delete
    public Errand DeleteErrand(int id) {
      Errand dbEntry = context.Errands.FirstOrDefault(e => e.ErrandId == id);
      if (dbEntry!=null) {
        context.Errands.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }

    public void SaveSample(Sample sample) {
      if (sample.SampleId == 0) {
        context.Samples.Add(sample);
      }
      context.SaveChanges();
    }

    public void SavePicture(Picture picture) {
      if (picture.PictureId == 0) {
        context.Pictures.Add(picture);
      }
      context.SaveChanges();
    }
  }
}

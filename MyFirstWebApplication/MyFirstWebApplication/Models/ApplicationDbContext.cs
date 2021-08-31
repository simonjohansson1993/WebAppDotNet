using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using environment_crime.Models;
using Microsoft.EntityFrameworkCore;
namespace environment_crime.Models {
  public class ApplicationDbContext : DbContext{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
    }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Errand> Errands { get; set; }
    public DbSet<ErrandStatus> ErrandStatuses { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Sample> Samples { get; set; }
    
    public DbSet<Sequence> Sequences { get; set; }
  }
  }


using System;
using EmployeeCrudManager.Storage.EFModels;
using Microsoft.EntityFrameworkCore;
namespace EmployeeCrudManager.Storage {
    public class ApplicationContext : DbContext {

        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base (options) { }

        public DbSet<EmployeeInformation> EmployeeInformations { get; set; }
    }
}
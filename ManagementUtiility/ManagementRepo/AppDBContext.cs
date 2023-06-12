using ManagemeantModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementRepo
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> option):base(option)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<CompanyInfo>  CompanyInfos{ get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<SparePart> spareParts { get; set; }
        public DbSet<SparePartReport> SparePartReports { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<PrescribedPart> PrescribedParts { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PublicReport> PublicReports { get; set; }

        public DbSet<TestPrice> TestPrices { get; set; }

    }
}

using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository_Classes
{
    public class InformationDbContext : DbContext
    {
        public virtual DbSet<ContactInformation> ContactInformations { get; set; }
        public virtual DbSet<DepartmentInformation> DepartmentInformations { get; set; }
        public virtual DbSet<IDInformation> IDInformations { get; set; }
        public virtual DbSet<InternCompany> InternCompanies { get; set; }
        public virtual DbSet<PersonelInformation> PersonelInformations { get; set; }
        public virtual DbSet<VolunteerInformation> VolunteerInformations { get; set; }

        public InformationDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
    }
}

using EntityLayer.Member_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository_Classes
{
    public class LoginDbContext : DbContext
    {
        public virtual DbSet<CompanyManager> CompanyManagers { get; set; }
        public virtual DbSet<MemberStudent> MemberStudents { get; set; }
        public virtual DbSet<SystemManager> SystemManagers { get; set; }

        public LoginDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
    }
}

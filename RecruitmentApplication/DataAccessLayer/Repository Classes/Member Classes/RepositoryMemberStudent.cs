using DataAccessLayer.Repository_Interfaces.Member_Interfaces;
using EntityLayer.Member_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository_Classes.Member_Classes
{
    public class RepositoryMemberStudent : Repository<MemberStudent> , IRepositoryMemberStudent
    {
        public InformationDbContext MemberStudentDbContext { get { return Context as InformationDbContext; } }

        public RepositoryMemberStudent(LoginDbContext context) : base(context)
        {

        }
    }
}

using DataAccessLayer.Repository_Interfaces.Information_Interfaces;
using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository_Classes.Information_Classes
{
    public class RepositoryVolunteer : Repository<VolunteerInformation> , IRepositoryVolunteer
    {
        public InformationDbContext VolunteerDbContext { get { return Context as InformationDbContext; } }

        public RepositoryVolunteer(InformationDbContext context) : base(context)
        {

        }

        public void RemoveAll(int studentID)
        {
            Expression<Func<VolunteerInformation, bool>> expression = currentVoluntariness => currentVoluntariness.StudentID == studentID;
            List<VolunteerInformation> studentVoluntariness = Find(expression).ToList();

            for (int currentDepartment = 0; currentDepartment < studentVoluntariness.Count; currentDepartment++)
            {
                Remove(studentVoluntariness[currentDepartment]);
            }
        }
    }
}

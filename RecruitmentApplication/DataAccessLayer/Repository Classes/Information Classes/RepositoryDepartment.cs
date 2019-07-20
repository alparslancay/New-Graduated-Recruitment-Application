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
    public class RepositoryDepartment : Repository<DepartmentInformation> , IRepositoryDepartment
    {
        public InformationDbContext DepartmentDbContext { get { return Context as InformationDbContext; } }

        public RepositoryDepartment(InformationDbContext context) : base(context)
        {

        }

        public void RemoveAll(int studentID)
        {
            Expression<Func<DepartmentInformation, bool>> expression = currentDepartment => currentDepartment.StudentID == studentID;
            List<DepartmentInformation> schoolDepartments = Find(expression).ToList();

            for (int currentDepartment = 0; currentDepartment < schoolDepartments.Count; currentDepartment++)
            {
                Remove(schoolDepartments[currentDepartment]);
            }
        }
    }
}

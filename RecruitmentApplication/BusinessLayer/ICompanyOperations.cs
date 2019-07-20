using DataAccessLayer.UnitOfWork;
using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ICompanyOperations
    {
        List<StudentInformation> SortByGPA(string departmentName);
        List<StudentInformation> SortByKnowledgeEnglish(string departmentName);
        List<StudentInformation> SortByGPAEnglish(string departmentName);
        List<StudentInformation> TakeListByDepartment(string departmentName);

        bool OfferJob(StudentInformation offeredStudent, string offerText);
        bool RegisterSystem(string userName, string password);
        bool DeleteAccount(string userName);

        StudentInformation ViewStudentInformation(int studentNumber);
    }
}

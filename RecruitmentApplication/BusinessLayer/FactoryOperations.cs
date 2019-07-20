using EntityLayer.Member_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FactoryOperations
    {
        ISystemManager GetSystemManagerOperations()
        {
            return new SystemManager();
        }

        ICompanyOperations GetCompanyOperations(CompanyManager companyManager)
        {
            return new CompanyOperations(companyManager);
        }

        IStudentOperations GetStudentOperations(MemberStudent memberStudent)
        {
            return new StudentOperations(memberStudent);
        }

        ILoginController GetLoginController()
        {
            return new LoginController();
        }
    }
}

using EntityLayer.Member_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ILoginController
    {
        MemberStudent FindStudent(string userName, string password);
        CompanyManager FindCompanyManager(string userName, string password);
        SystemManager FindSystemManager(string userName, string password);
    }
}

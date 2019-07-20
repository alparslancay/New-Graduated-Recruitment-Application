using EntityLayer.Member_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ISystemManager
    {
        bool StudentRegisterAccept(MemberStudent memberStudent);
        bool CompanyRegisterAccept(CompanyManager companyManager);
        List<MemberStudent> RegisterRequestStudentList();
        List<CompanyManager> RegisterRequestCompanyList();
        bool RejectStudentRegisterRequest(MemberStudent memberStudent);
        bool RejectCompanyRegisterRequest(CompanyManager companyManager);
    }
}

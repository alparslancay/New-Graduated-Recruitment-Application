using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository_Classes;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Member_Classes;

namespace BusinessLayer
{
    public class SystemManager : ISystemManager
    {
        UnitOfWorkLogin loginBase;

        public SystemManager()
        {
            loginBase = new UnitOfWorkLogin(new LoginDbContext("GratuatedLoginDb"));
        }

        public bool CompanyRegisterAccept(CompanyManager companyManager)
        {
            try
            {
                companyManager.IsAccepted = true;
                loginBase.Complete();
                return true;
            }

            catch
            {
                return false;
            }
        }

        public List<CompanyManager> RegisterRequestCompanyList()
        {
            Expression<Func<CompanyManager, bool>> expression = companyManager => !companyManager.IsAccepted;
            return loginBase.CompanyManager.Find(expression).ToList();
        }

        public List<MemberStudent> RegisterRequestStudentList()
        {
            Expression<Func<MemberStudent, bool>> expression = memberStudent => !memberStudent.IsAccepted;
            return loginBase.MemberStudent.Find(expression).ToList();
        }

        public bool RejectCompanyRegisterRequest(CompanyManager companyManager)
        {
            try
            {

                loginBase.CompanyManager.Remove(companyManager);
                loginBase.Complete();
                return true;
            }

            catch
            {
                return false;
            }
        }

        public bool RejectStudentRegisterRequest(MemberStudent memberStudent)
        {
            try
            {

                loginBase.MemberStudent.Remove(memberStudent);
                loginBase.Complete();
                return true;
            }

            catch
            {
                return false;
            }
        }

        public bool StudentRegisterAccept(MemberStudent memberStudent)
        {
            try
            {
                memberStudent.IsAccepted = true;
                loginBase.Complete();
                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}

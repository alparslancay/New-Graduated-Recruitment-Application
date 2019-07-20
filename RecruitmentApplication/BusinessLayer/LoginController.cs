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
    public class LoginController : ILoginController
    {
        UnitOfWorkLogin loginBase;

        public LoginController()
        {
            loginBase = new UnitOfWorkLogin(new LoginDbContext("GratuatedLoginDb"));
        }
        public CompanyManager FindCompanyManager(string userName, string password)
        {
            Expression<Func<CompanyManager, bool>> expression = companyManager => companyManager.UserName == userName && companyManager.Password == password;

            return loginBase.CompanyManager.Find(expression).First();
        }

        public MemberStudent FindStudent(string userName, string password)
        {
            Expression<Func<MemberStudent, bool>> expression = memberStudent => memberStudent.UserName == userName && memberStudent.Password == password;

            return loginBase.MemberStudent.Find(expression).First();
        }

        public SystemManager FindSystemManager(string userName, string password)
        {
            Expression<Func<SystemManager, bool>> expression = systemManager => systemManager.UserName == userName && systemManager.Password == password;

            return loginBase.SystemManager.Find(expression).First();
        }
    }
}

using DataAccessLayer.Repository_Classes;
using DataAccessLayer.Repository_Classes.Member_Classes;
using DataAccessLayer.Repository_Interfaces.Member_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWorkLogin : IUnitOfWorkLogin
    {
        private readonly LoginDbContext m_dbContext;

        public IRepositoryCompanyManager CompanyManager { get; private set; }

        public IRepositoryMemberStudent MemberStudent { get; private set; }

        public IRepositorySystemManager SystemManager { get; private set; }

        public UnitOfWorkLogin(LoginDbContext loginDbContext)
        {
            m_dbContext = loginDbContext;

            CompanyManager = new RepositoryCompanyManager(m_dbContext);
            MemberStudent = new RepositoryMemberStudent(m_dbContext);
            SystemManager = new RepositorySystemManager(m_dbContext);
        }

        public int Complete()
        {
           return m_dbContext.SaveChanges();
        }
    }
}

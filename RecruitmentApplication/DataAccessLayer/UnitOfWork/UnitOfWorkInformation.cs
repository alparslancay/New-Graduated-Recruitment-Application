using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository_Classes;
using DataAccessLayer.Repository_Classes.Information_Classes;
using DataAccessLayer.Repository_Classes.Member_Classes;
using DataAccessLayer.Repository_Interfaces.Information_Interfaces;
using DataAccessLayer.Repository_Interfaces.Member_Interfaces;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWorkInformation : IUnitOfWorkInformation
    {
        private readonly InformationDbContext m_dbContext;

        public IRepositoryContact Contact { get; private set; }

        public IRepositoryDepartment Department { get; private set; }

        public IRepositoryID ID { get; private set; }

        public IRepositoryIntern Intern { get; private set; }

        public IRepositoryPersonel Personel { get; private set; }

        public IRepositoryVolunteer Volunteer { get; private set; }

        public IRepositoryBusinessOffer Offers { get; private set; }

        public UnitOfWorkInformation(InformationDbContext projectDbContext)
        {
            m_dbContext = projectDbContext;
            Contact = new RepositoryContact(m_dbContext);
            Department = new RepositoryDepartment(m_dbContext);
            ID = new RepositoryID(m_dbContext);
            Intern = new RepositoryIntern(m_dbContext);
            Personel = new RepositoryPersonel(m_dbContext);
            Volunteer = new RepositoryVolunteer(m_dbContext);
            Offers = new RepositoryBusinessOffer(m_dbContext);
        }

       

        public int Complete()
        {
            return m_dbContext.SaveChanges();
        }
    }
}

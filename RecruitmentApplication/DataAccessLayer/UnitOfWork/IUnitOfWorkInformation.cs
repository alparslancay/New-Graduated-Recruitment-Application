using DataAccessLayer.Repository_Interfaces.Information_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWorkInformation
    {
        IRepositoryContact Contact { get; }
        IRepositoryDepartment Department { get; }
        IRepositoryID ID { get; }
        IRepositoryIntern Intern { get; }
        IRepositoryPersonel Personel { get; }
        IRepositoryVolunteer Volunteer { get; }
        IRepositoryBusinessOffer Offers { get; }
        int Complete();
    }
}

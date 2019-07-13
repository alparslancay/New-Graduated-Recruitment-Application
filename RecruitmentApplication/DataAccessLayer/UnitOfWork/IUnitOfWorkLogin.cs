using DataAccessLayer.Repository_Interfaces.Member_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWorkLogin
    {
        IRepositoryCompanyManager CompanyManager { get; }
        IRepositoryMemberStudent MemberStudent { get; }
        IRepositorySystemManager SystemManager { get; }
        int Complete();
    }
}

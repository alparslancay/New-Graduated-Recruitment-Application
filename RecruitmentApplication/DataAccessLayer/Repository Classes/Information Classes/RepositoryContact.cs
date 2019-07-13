using DataAccessLayer.Repository_Interfaces.Information_Interfaces;
using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository_Classes.Information_Classes
{
    public class RepositoryContact : Repository<ContactInformation> , IRepositoryContact
    {
        public InformationDbContext ContactDbContext { get { return Context as InformationDbContext; } }

        public RepositoryContact(InformationDbContext context) : base(context)
        {

        }
    }
}

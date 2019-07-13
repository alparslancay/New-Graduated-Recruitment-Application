using DataAccessLayer.Repository_Interfaces.Information_Interfaces;
using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository_Classes.Information_Classes
{
    public class RepositoryIntern : Repository<InternCompany> , IRepositoryIntern
    {
        public InformationDbContext InternDbContext { get { return Context as InformationDbContext; } }

        public RepositoryIntern(InformationDbContext context) : base(context)
        {

        }
    }
}

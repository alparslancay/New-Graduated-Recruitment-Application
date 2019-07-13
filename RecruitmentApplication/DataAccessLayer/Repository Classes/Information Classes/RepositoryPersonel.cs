using DataAccessLayer.Repository_Interfaces.Information_Interfaces;
using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository_Classes.Information_Classes
{
    public class RepositoryPersonel : Repository<PersonelInformation> , IRepositoryPersonel
    {
        public InformationDbContext PersonelDbContext { get { return Context as InformationDbContext; } }

        public RepositoryPersonel(InformationDbContext context) : base(context)
        {

        }
    }
}

using DataAccessLayer.Repository_Interfaces.Information_Interfaces;
using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository_Classes.Information_Classes
{
    public class RepositoryBusinessOffer : Repository<BusinessOfferInformation> , IRepositoryBusinessOffer
    {
        public InformationDbContext OfferDbContext { get { return Context as InformationDbContext; } }

        public RepositoryBusinessOffer(InformationDbContext context) : base(context)
        {

        }

        public void RemoveAll(int studentID)
        {
            Expression<Func<BusinessOfferInformation, bool>> expression = currentOffer => currentOffer.StudentID == studentID;
            List<BusinessOfferInformation> studentOffers = Find(expression).ToList();

            for (int currentDepartment = 0; currentDepartment < studentOffers.Count; currentDepartment++)
            {
                Remove(studentOffers[currentDepartment]);
            }
        }
    }
}

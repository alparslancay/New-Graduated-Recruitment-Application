using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Information_Classes
{
    public class StudentInformation
    {
        public List<DepartmentInformation> schoolDepartments;
        public IDInformation identificationInformation;
        public ContactInformation contactInformation;
        public PersonelInformation personelInformation;
        public List<VolunteerInformation> volunteerInformations;
        public List<InternCompany> internCompanies;
        public List<BusinessOfferInformation> businessOffers;
    }
}

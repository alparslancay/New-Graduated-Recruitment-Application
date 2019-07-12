using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Information_Classes
{
    public class StudentInformation
    {
        List<DepartmentInformation> schoolDepartments;
        IDInformation identificationInformation;
        ContactInformation contactInformation;
        PersonelInformation personelInformation;
        List<VolunteerInformation> volunteerInformations;
        List<InternCompany> internCompanies;
        List<BusinessOfferInformation> businessOffers;
    }
}

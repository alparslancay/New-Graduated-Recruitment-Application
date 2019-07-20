using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repository_Classes;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Information_Classes;
using EntityLayer.Member_Classes;

namespace BusinessLayer
{
    public class CompanyOperations : ICompanyOperations
    {
        private readonly UnitOfWorkInformation InformationBase;

        private readonly UnitOfWorkLogin LoginBase;

        private CompanyManager companyManager;
        List<StudentInformation> studentInformations;
        private Hash studentHash;
        private object offerInformation;

        public CompanyOperations(CompanyManager companyManager)
        {
            InformationBase = new UnitOfWorkInformation(new InformationDbContext("GratuatedInformationDb"));
            LoginBase = new UnitOfWorkLogin(new LoginDbContext("GratuatedLoginDb"));
            studentInformations = ImportStudents();
            studentHash = new Hash(studentInformations);

            this.companyManager = companyManager;
        }

        public bool DeleteAccount(string userName)
        {
            try
            {
                LoginBase.CompanyManager.Remove(companyManager);
                LoginBase.Complete();
                return true;
            }
            
            catch
            {
                return false;
            }
        }

        public bool OfferJob(StudentInformation offeredStudent, string offerText)
        {
            try
            {
                BusinessOfferInformation newOffer = new BusinessOfferInformation();
                newOffer.CompanyID = companyManager.ID;
                newOffer.OfferText = offerText;
                newOffer.StudentID = offeredStudent.personelInformation.ID;
                InformationBase.Offers.Add(newOffer);
                InformationBase.Complete();

                return true;
            }

            catch
            {
                return false;
            }
        }

        public bool RegisterSystem(string userName, string password)
        {
            try
            {

                CompanyManager newCompanyManager = new CompanyManager();

                newCompanyManager.UserName = userName;
                newCompanyManager.Password = password;
                newCompanyManager.IsAccepted = false;

                LoginBase.CompanyManager.Add(newCompanyManager);
                LoginBase.Complete();
                return true;
            }

            catch
            {
                return false;
            }
        }

        private List<StudentInformation> ImportStudents()
        {
            List<StudentInformation> studentList = new List<StudentInformation>();

            List<BusinessOfferInformation> businessOfferInformations = InformationBase.Offers.GetAll().ToList();
            List<ContactInformation> contactInformations = InformationBase.Contact.GetAll().ToList();
            List<IDInformation> IDInformations = InformationBase.ID.GetAll().ToList();
            List<InternCompany> internCompanies = InformationBase.Intern.GetAll().ToList();
            List<PersonelInformation> personelInformations = InformationBase.Personel.GetAll().ToList();
            List<DepartmentInformation> schoolDepartmentInformations = InformationBase.Department.GetAll().ToList();
            List<VolunteerInformation> volunteerInformations = InformationBase.Volunteer.GetAll().ToList();
           

            for (int numberRecorder = 0; numberRecorder < IDInformations.Count; numberRecorder++)
            {
                StudentInformation studentInformation = new StudentInformation();

                studentInformation.businessOffers = GetStudentOffers(numberRecorder,businessOfferInformations);
                studentInformation.contactInformation = contactInformations[numberRecorder];
                studentInformation.identificationInformation = IDInformations[numberRecorder];
                studentInformation.internCompanies = GetStudentIntern(numberRecorder,internCompanies);
                studentInformation.personelInformation = personelInformations[numberRecorder];
                studentInformation.schoolDepartments = GetSchoolInformation(numberRecorder,schoolDepartmentInformations);
                studentInformation.volunteerInformations = GetStudentVolunteer(numberRecorder,volunteerInformations);

                studentList.Add(studentInformation);

            }

            return studentList;
        }

        private List<BusinessOfferInformation> GetStudentOffers(int studentID, List<BusinessOfferInformation> studentsOffers)
        {
            bool offersOfStudent(BusinessOfferInformation offer) => offer.StudentID == studentID;

            return studentsOffers.FindAll(offersOfStudent);
        }

        private List<InternCompany> GetStudentIntern(int studentID, List<InternCompany> studentInterns)
        {
            bool internOfStudent(InternCompany intern) => intern.StudentID == studentID;

            return studentInterns.FindAll(internOfStudent);
        }

        private List<DepartmentInformation> GetSchoolInformation(int studentID, List<DepartmentInformation> studentsDeparments)
        {
            bool deparmentsOfStudent(DepartmentInformation department) => department.StudentID == studentID;

            return studentsDeparments.FindAll(deparmentsOfStudent);
        }

        private List<VolunteerInformation> GetStudentVolunteer(int studentID, List<VolunteerInformation> studentsVolunteers)
        {
            bool volunteerOfStudent(VolunteerInformation volunteer) => volunteer.StudentID == studentID;

            return studentsVolunteers.FindAll(volunteerOfStudent);
        }

        public List<StudentInformation> SortByGPA(string departmentName)
        {
            return studentHash.ListSortedGPA(departmentName);
        }

        public List<StudentInformation> SortByGPAEnglish(string departmentName)
        {
            return studentHash.ListSortedGPAEnglish(departmentName);
        }

        public List<StudentInformation> SortByKnowledgeEnglish(string departmentName)
        {
            return studentHash.ListSortedEnglish(departmentName);
        }

        public List<StudentInformation> GetListByDepartment(string departmentName)
        {
            return studentHash.ListByDepartment(departmentName);
        }

        public StudentInformation ViewStudentInformation(int studentNumber)
        {
            return studentInformations[studentNumber];
        }
    }
}

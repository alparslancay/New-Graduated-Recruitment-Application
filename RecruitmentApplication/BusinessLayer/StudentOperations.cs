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
    public class StudentOperations : IStudentOperations
    {
        UnitOfWorkLogin LoginBase;
        UnitOfWorkInformation InformationBase;

        public StudentOperations()
        {
            InformationBase = new UnitOfWorkInformation(new InformationDbContext("GratuatedInformationDb"));
            LoginBase = new UnitOfWorkLogin(new LoginDbContext("GratuatedLoginDb"));
        }

        public bool DeleteAccount(StudentInformation studentInformation)
        {
            try
            {

                int studentID = studentInformation.identificationInformation.ID;

                LoginBase.MemberStudent.Remove(LoginBase.MemberStudent.Get(studentID));
                LoginBase.Complete();

                InformationBase.ID.Remove(studentInformation.identificationInformation);
                InformationBase.Contact.Remove(studentInformation.contactInformation);
                InformationBase.Personel.Remove(studentInformation.personelInformation);

                InformationBase.Department.RemoveAll(studentID);
                InformationBase.Intern.RemoveAll(studentID);
                InformationBase.Volunteer.RemoveAll(studentID);
                InformationBase.Offers.RemoveAll(studentID);

                InformationBase.Complete();

                return true;
            }

            catch
            {
                return false;
            }
            
        }

        public bool EditInformation(StudentInformation studentInformation)
        {
            try
            {

                StudentInformation currentStudent = studentInformation;

                InformationBase.Complete();


                return true;
            }

            catch
            {
                return false;
            }


        }

        public bool RegisterSystem(MemberStudent memberStudent)
        {
            try
            {
                LoginBase.MemberStudent.Add(memberStudent);
                LoginBase.Complete();
                return true;
            }

            catch
            {
                return false;
            }
        }

        public StudentInformation ViewStudentInformation(int studentID)
        {
            StudentInformation studentInformation = new StudentInformation
            {
                businessOffers = TakeStudentOffers(studentID),
                contactInformation = InformationBase.Contact.Get(studentID),
                identificationInformation = InformationBase.ID.Get(studentID),
                internCompanies = TakeStudentIntern(studentID),
                personelInformation = InformationBase.Personel.Get(studentID),
                schoolDepartments = TakeSchoolInformation(studentID),
                volunteerInformations = TakeStudentVolunteer(studentID)
            };

            return studentInformation;
        }

        private List<BusinessOfferInformation> TakeStudentOffers(int studentID)
        {
            Expression<Func<BusinessOfferInformation,bool>> expression = offerStudents => offerStudents.StudentID == studentID;

            return InformationBase.Offers.Find(expression).ToList();
        }

        private List<InternCompany> TakeStudentIntern(int studentID)
        {
            Expression<Func<InternCompany, bool>> expression = studentIntern => studentIntern.StudentID == studentID;

            return InformationBase.Intern.Find(expression).ToList();
        }

        private List<DepartmentInformation> TakeSchoolInformation(int studentID)
        {
            Expression<Func<DepartmentInformation, bool>> expression = schoolDepartment => schoolDepartment.StudentID == studentID;

            return InformationBase.Department.Find(expression).ToList();
        }

        private List<VolunteerInformation> TakeStudentVolunteer(int studentID)
        {
            Expression<Func<VolunteerInformation, bool>> expression = studentVolunteer => studentVolunteer.StudentID == studentID;

            return InformationBase.Volunteer.Find(expression).ToList();
        }

    }
}

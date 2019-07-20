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
        MemberStudent memberStudent;
        int studentID;

        public StudentOperations(MemberStudent memberStudent)
        {
            InformationBase = new UnitOfWorkInformation(new InformationDbContext("GratuatedInformationDb"));
            LoginBase = new UnitOfWorkLogin(new LoginDbContext("GratuatedLoginDb"));
            this.memberStudent = memberStudent;
            studentID = memberStudent.ID;
        }

        public bool DeleteAccount()
        {
            try
            {
                
                LoginBase.MemberStudent.Remove(memberStudent);
                LoginBase.Complete();

                StudentInformation studentInformation = ViewStudentInformation();

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

        public StudentInformation ViewStudentInformation()
        {
            StudentInformation studentInformation = new StudentInformation
            {
                businessOffers = GetStudentOffers(studentID),
                contactInformation = InformationBase.Contact.Get(studentID),
                identificationInformation = InformationBase.ID.Get(studentID),
                internCompanies = GetStudentIntern(studentID),
                personelInformation = InformationBase.Personel.Get(studentID),
                schoolDepartments = GetSchoolInformation(studentID),
                volunteerInformations = GetStudentVolunteer(studentID)
            };

            return studentInformation;
        }

        private List<BusinessOfferInformation> GetStudentOffers(int studentID)
        {
            Expression<Func<BusinessOfferInformation,bool>> expression = offerStudents => offerStudents.StudentID == studentID;

            return InformationBase.Offers.Find(expression).ToList();
        }

        private List<InternCompany> GetStudentIntern(int studentID)
        {
            Expression<Func<InternCompany, bool>> expression = studentIntern => studentIntern.StudentID == studentID;

            return InformationBase.Intern.Find(expression).ToList();
        }

        private List<DepartmentInformation> GetSchoolInformation(int studentID)
        {
            Expression<Func<DepartmentInformation, bool>> expression = schoolDepartment => schoolDepartment.StudentID == studentID;

            return InformationBase.Department.Find(expression).ToList();
        }

        private List<VolunteerInformation> GetStudentVolunteer(int studentID)
        {
            Expression<Func<VolunteerInformation, bool>> expression = studentVolunteer => studentVolunteer.StudentID == studentID;

            return InformationBase.Volunteer.Find(expression).ToList();
        }

    }
}

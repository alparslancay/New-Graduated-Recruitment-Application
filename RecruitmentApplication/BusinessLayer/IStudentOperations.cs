using EntityLayer.Information_Classes;
using EntityLayer.Member_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IStudentOperations
    {
        bool EditInformation(StudentInformation studentInformation);
        bool DeleteAccount();
        bool RegisterSystem(MemberStudent memberStudent);
        StudentInformation ViewStudentInformation();
    }
}

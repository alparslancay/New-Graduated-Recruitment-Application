using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Hash
    {
        HashNode[] table;

        List<string> Departments;

        public Hash(List<StudentInformation> studentList)
        {
            Departments = FindDepartments(studentList);

            table = new HashNode[Departments.Count];

            foreach (var student in studentList)
            {
                AddStudent(student);
            }
        }

        public List<StudentInformation> ListByDepartment(string departmentName)
        {
            List<StudentInformation> ogrenciler = new List<StudentInformation>();

            HashNode entry = table[HashFunction(departmentName)];
            while (entry.NextValue != null)
                ogrenciler.Add(entry.Student);

            return ogrenciler;


        }

        public List<StudentInformation> ListSortedGPA(string departmentName)
        {
            HeapGPA sortedGPA = new HeapGPA(ListByDepartment(departmentName));

            return sortedGPA.SortedGPAList();
        }

        public List<StudentInformation> ListSortedGPAEnglish(string departmentName)
        {
            HeapKnowledgeEnglishGPA sortedEnglishGPA = new HeapKnowledgeEnglishGPA(ListByDepartment(departmentName));

            return sortedEnglishGPA.SortedGPAList();
        }

        public List<StudentInformation> ListSortedEnglish(string departmentName)
        {
            HeapKnowledgeEnglish sortedEnglish = new HeapKnowledgeEnglish(ListByDepartment(departmentName));

            return sortedEnglish.SortedGPAList();
        }


        private void AddStudent(StudentInformation newStudent)
        {
            int hash = HashFunction(newStudent.schoolDepartments[0].DepartmentName);
            if (table[hash] == null)
                table[hash] = new HashNode(newStudent);
            else
            {
                HashNode entry = table[hash];
                while (entry.NextValue != null)
                    entry = entry.NextValue;

                entry.NextValue = new HashNode(newStudent);
            }
        }

        private int HashFunction(string bolumAdi)
        {
            for (int i = 0; i < Departments.Count; i++)
            {
                if (bolumAdi == Departments[i]) return i;
            }

            return -1;
        }

        private List<string> FindDepartments(List<StudentInformation> studentList)
        {
            List<string> DepartmentsList = new List<string>();

            foreach (var student in studentList)
            {
                for (int i = 0; i < Departments.Count; i++)
                {
                    if (student.schoolDepartments[0].DepartmentName != Departments[i]) Departments.Add(student.schoolDepartments[0].DepartmentName);
                }
            }

            return DepartmentsList;
        }

    }
}

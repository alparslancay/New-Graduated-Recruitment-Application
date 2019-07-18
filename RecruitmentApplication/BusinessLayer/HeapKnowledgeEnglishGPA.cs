using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HeapKnowledgeEnglishGPA
    {

        private int currentSize;
        private List<StudentInformation> agacDugumleri;
        public HeapKnowledgeEnglishGPA(List<StudentInformation> studentList)
        {
            currentSize = 0;
            agacDugumleri = new List<StudentInformation>();

            foreach (var currentStudent in studentList)
            {
                Ekle(currentStudent);
            }
        }
        public List<StudentInformation> SortedGPAList()
        {
            List<StudentInformation> yedekListStudent = new List<StudentInformation>();

            for (int i = 0; i < agacDugumleri.Count; i++)
            {
                yedekListStudent.Add(agacDugumleri[i]);
            }
            List<StudentInformation> siraliListStudent = new List<StudentInformation>();
            while (!IsEmpty())
            {
                siraliListStudent.Add(Remove(0));

            }
            agacDugumleri = yedekListStudent;
            return siraliListStudent;
        }

        private void Ekle(StudentInformation entity)
        {
            agacDugumleri.Add(entity);
            MoveToUpStudent(currentSize++);
        }

        private void MoveToUpStudent(int index)
        {
            int parent = (index - 1) / 2;
            StudentInformation bottom = agacDugumleri[index];
            while (index > 0 && agacDugumleri[parent].schoolDepartments[0].GPA <= bottom.schoolDepartments[0].GPA)
            {
                if (agacDugumleri[parent].schoolDepartments[0].GPA == bottom.schoolDepartments[0].GPA && string.Compare(agacDugumleri[parent].personelInformation.KnowledgeEnglish, bottom.personelInformation.KnowledgeEnglish) == -1)
                {
                    break;
                }
                agacDugumleri[index] = agacDugumleri[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            agacDugumleri[index] = bottom;
        }

        private void MoveToDownStudent(int index)
        {
            int largerChild;
            StudentInformation top = agacDugumleri[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;

                if (rightChild < currentSize && agacDugumleri[leftChild].schoolDepartments[0].GPA <= agacDugumleri[rightChild].schoolDepartments[0].GPA)
                {
                    if (agacDugumleri[leftChild].schoolDepartments[0].GPA == agacDugumleri[rightChild].schoolDepartments[0].GPA && string.Compare(agacDugumleri[rightChild].personelInformation.KnowledgeEnglish, agacDugumleri[leftChild].personelInformation.KnowledgeEnglish) == -1)
                    {
                        largerChild = leftChild;
                    }
                    else
                        largerChild = rightChild;
                }

                else
                    largerChild = leftChild;
                if (top.schoolDepartments[0].GPA >= agacDugumleri[largerChild].schoolDepartments[0].GPA)
                {
                    if (top.schoolDepartments[0].GPA == agacDugumleri[largerChild].schoolDepartments[0].GPA && string.Compare(top.personelInformation.KnowledgeEnglish, agacDugumleri[largerChild].personelInformation.KnowledgeEnglish) == -1)
                    {

                    }
                    else
                        break;
                }

                agacDugumleri[index] = agacDugumleri[largerChild];
                index = largerChild;
            }
            agacDugumleri[index] = top;
        }

        private StudentInformation Remove(int index)
        {
            StudentInformation root = agacDugumleri[index];
            agacDugumleri[index] = agacDugumleri[--currentSize];
            MoveToDownStudent(index);
            return root;
        }

        private bool IsEmpty()
        {
            return currentSize == 0;

        }

    }
}

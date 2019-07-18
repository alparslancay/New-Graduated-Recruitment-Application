using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HeapKnowledgeEnglish
    {

        private int currentSize;
        private List<StudentInformation> agacDugumleri;
        public HeapKnowledgeEnglish(List<StudentInformation> studentList)
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
            while (index > 0 && string.Compare(agacDugumleri[parent].personelInformation.KnowledgeEnglish, bottom.personelInformation.KnowledgeEnglish) == 1)
            {
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

                if (rightChild < currentSize && string.Compare(agacDugumleri[leftChild].personelInformation.KnowledgeEnglish, agacDugumleri[rightChild].personelInformation.KnowledgeEnglish) == -1)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (string.Compare(top.personelInformation.KnowledgeEnglish, agacDugumleri[largerChild].personelInformation.KnowledgeEnglish) == 1)
                    break;
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

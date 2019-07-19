using EntityLayer.Information_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HashNode
    {
        public HashNode NextValue { get; set; }

        public StudentInformation Student { get; set; }

        public HashNode(StudentInformation studentInformation)
        {
            this.Student = studentInformation;
        }
    }
}

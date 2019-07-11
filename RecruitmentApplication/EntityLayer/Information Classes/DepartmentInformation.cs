using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Information_Classes
{
    public class DepartmentInformation
    {
        public int ID { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public double GPA { get; set; }
        public string DepartmentName { get; set; }
    }
}

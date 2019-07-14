using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Member_Classes
{
    public class MemberStudent : MemberLoginInformationADT
    {
        public string IsAccepted { get; set; }
        public string RegisterDescription { get; set; }
    }
}

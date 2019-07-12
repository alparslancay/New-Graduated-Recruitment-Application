using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Information_Classes
{
    public class BusinessOfferInformation
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string OfferText { get; set; }
        public int StudentID { get; set; }
    }
}

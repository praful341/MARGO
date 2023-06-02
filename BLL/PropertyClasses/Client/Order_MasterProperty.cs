using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.PropertyClasses.Master
{
    public class Order_MasterProperty
    {
        public Int64 Order_ID { get; set; }
        public string Order_Date { get; set; }
        public Int64 Enquiry_No { get; set; }
        public string Confirm_Date { get; set; }
        public Int64 Duration { get; set; }
        public string Delivery_Date { get; set; }
        public int Is_Applicable { get; set; }
        public string AMC_Start_Date { get; set; }
        public string AMC_End_Date { get; set; }      
    }
}

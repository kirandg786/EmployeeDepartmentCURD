using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.VM
{
    public class EmployeeVM
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Adderss { get; set; }
        public int DapartmentId { get; set; }

        public string DapartmentName { get; set; }
    }
}
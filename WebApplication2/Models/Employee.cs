using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is Required.")]
        public string Name { get; set; }
        public string Adderss { get; set; }

        [Required(ErrorMessage = "DapartmentId is Required.")]
        public int DapartmentId { get; set; }
        
    
}
}
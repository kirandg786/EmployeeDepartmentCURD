using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table("Dapartment")]
    public class Dapartment
    {
        public int DapartmentId { get; set; }
        public string Name { get; set; }
    }
}
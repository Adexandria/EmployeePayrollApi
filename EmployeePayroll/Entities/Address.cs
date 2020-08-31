using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayroll.Entities
{
    public class Address
    {
        [Key]
        public Guid HomeAddressId { get; set; }
       
        
        public string Address1 { get; set; }
    
        public string Address2 { get; set; }
       
 
        public string City { get; set; }
       
        public string Region { get; set; }
       
        
        public int PostalCode { get; set; }
       
       
        public string Country { get; set; }
    }
}
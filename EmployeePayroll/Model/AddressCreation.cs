using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class AddressCreation
    {
        public Guid Id { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Enter Address")]
        public string Address1 { get; set; }
        [StringLength(40)]
        public string Address2 { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "City")]
        public string City { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Enter Region")]
        public string Region { get; set; }

     
        [Required(ErrorMessage = "Enter postalcode")]
        public int PostalCode { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Enter Country")]
        public string Country { get; set; }
    }
}

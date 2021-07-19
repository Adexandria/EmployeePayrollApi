using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class EmployeeCreation
    {
        [Required(ErrorMessage ="Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Enter FirstName")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Enter LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "NotStated/Male/Female/Non_Binary")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "yyyy-mm-dd")]
        public DateTimeOffset DateOfBirth { get; set; }
        [Required(ErrorMessage = "Active/Terminated")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Professional")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Enter number")]
        public string Phonenumber { get; set; }
        public string Homenumber { get; set; } 
        [Required(ErrorMessage = "True/False")]
        public string IsAuthorizedToLeave { get; set; }
        [Required(ErrorMessage = "yyyy-mm-dd")]
        public DateTimeOffset StartDate { get; set; }
        [Required(ErrorMessage = "yyyy-mm-dd")]
        public DateTimeOffset UpdatedDate { get; set; }
  
       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace DRYModelValidation.Models
{
    public class Student
    {
        //Validation for the name property of a student
        //Data annotations are used for the input validation
        //these are implemented in the view using html helpers
        [Display(Name = "Student Name :")]
        [StringLength(50, MinimumLength = 5,
            ErrorMessage = "Name cannot be longer than 50 characters and shorter than 5 charcters.")]
        [RegularExpression(@"[a-zA-Z]*$", ErrorMessage = "Only letters and space allowed")]
        public string Name { get; set; }
        //For the Age property a student cannot be older than 70 or younger than 16
        [Display(Name = "Student Age :")]
        [Range(16, 70)]
        public int Age { get; set; }
        //valid student date of birth is only between 1950 and 2003
        [Display(Name = "Student Date of Birth :")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        [CustomValidation(typeof(CustomDateValidation), nameof(CustomDateValidation.CustomDateValidator))]
        public DateTime DateOfBirth { get; set; }

    }
}

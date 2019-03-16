using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DRYModelValidation
{
    /// <summary>
    /// here we created a custom date validation class which contains
    /// a costum date validator which checks for the condition impossed
    /// although it does not fully meet the specification, this project built on 16/03/2019
    /// for example, given the current year: person born on 19/07/2013 does not have 16 years
    /// however the validation will allow them to register since it only checks for year
    /// not the full date
    /// the custom validator only gets checked after form submission, use javascript for 
    /// live csheck on the webpage
    /// </summary>
    public class CustomDateValidation
    {
        
        public static ValidationResult CustomDateValidator(DateTime date)
        {

            if (DateTime.Now.Year - date.Year > 15 && DateTime.Now.Year - date.Year < 70)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The date you entered does not fit our requirements. If under age, please do not register.");
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidley.Models
{
    public class Min18YearsIfAMember : ValidationAttribute //the ValidationAttribute is a interface taht is being given to this class so this class can inherit the features of a validation attribute used in the class fields
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;  //the ObjectInstance method returns the object that is being referenced which in this case is the customer object 
            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if(customer.Birthday == null)
            {
                return new ValidationResult("Birthdate is required"); //the NEW validationResult indicates an error 
            }

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18) ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membership"); // using a crude if/else statement to determine if the customer is 18 years or older
        }
    }
}

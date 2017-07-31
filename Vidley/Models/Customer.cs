using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidley.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter customer's name.") ]//property where Name can not be null
        [StringLength(255)]//property that sets the minimum length to 255
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]//property that sets the public name to "Membership Type", the field Birthday has a validation attribute that determines if the customer is 18 years or older
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]//  property that sets the public name to "Date of Birth"
        [Min18YearsIfAMember] //this class is created and uses the interface for validation attribute to validate if the date of birth is 18 years or older to be a member
        public DateTime? Birthday { get; set; }
    }
}
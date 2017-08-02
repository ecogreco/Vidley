using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.Dtos
{
    public class CustomerDto //Dto stands for Data Transfer Object which are representations of the domain object being transfered over 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]//property where Name can not be null
        [StringLength(255)]//property that sets the minimum length to 255
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

        // [Min18YearsIfAMember] //this class is created and uses the interface for validation attribute to validate if the date of birth is 18 years or older to be a member
        public DateTime? Birthday { get; set; }
    }
}
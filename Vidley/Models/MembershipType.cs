using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidley.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string Type { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        //since there is a definate amount of objects in the Membership database these static readonly byte properties are included 
        //the static readonly byte pre-determined stats are in reference to the select values in the drop list on the CustomerForm with 0 being undecided and then the objects in the MembershipType Database 
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte QuarterAnnual = 3;
        public static readonly byte Annual = 4;
    }
}
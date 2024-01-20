using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPR23_24B.Models
{
    public class UserInfoUpdateModel
    {
        public string? Naam { get; set; }
        public string? Emailadres { get; set; }
        public string? TelefoonNummer { get; set; }
        public string? Postcode { get; set; }
        public DateTime? GeboorteDatum { get; set; }
        // Add other properties as needed
    }
}
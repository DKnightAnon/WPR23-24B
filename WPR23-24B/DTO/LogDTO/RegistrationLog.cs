using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPR23_24B.DTO.LogDTO
{
    public class RegistrationLog
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
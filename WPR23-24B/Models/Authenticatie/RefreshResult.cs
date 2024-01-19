using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPR23_24B.Models.Authenticatie
{
    public class RefreshResult
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace RedPaperEMS.Application.Models.Authentication
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double ExpireInMinutes { get; set; }
    }
}

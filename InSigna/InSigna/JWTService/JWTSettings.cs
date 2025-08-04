using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSigna.JWTService
{
    /// <summary>
    /// Class representing the configuration settings for JWT (JSON Web Token).
    /// </summary>
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public int ExpirationMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}

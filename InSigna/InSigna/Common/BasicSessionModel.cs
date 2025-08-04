using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSigna.Common
{
    /// <summary>
    /// Basic session model for user information.
    /// </summary>
    public class BasicSessionModel
    {
        public string Provider { get; set; } 
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}

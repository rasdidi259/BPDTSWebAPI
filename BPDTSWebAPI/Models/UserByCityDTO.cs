using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Models
{
    public class UserByCityDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IPAddress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string TestDTO { get; set; } = "yes";
    }
}

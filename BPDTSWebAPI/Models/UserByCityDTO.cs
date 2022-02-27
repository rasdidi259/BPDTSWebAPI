using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Models
{
    public class UserByCityDTO
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string IP_Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public bool DTOData { get; set; } = true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Models
{
    public class UserDTO : UserByCityDTO
    {
        public string City { get; set; }

    }
}

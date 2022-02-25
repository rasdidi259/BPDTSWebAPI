using AutoMapper;
using BPDTSWebAPI.Entities;
using BPDTSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Configurations
{
    public class MapperInitializer:Profile
    {

        /// <summary>
        /// Configures the DTOs to Data Models
        /// </summary>
        public MapperInitializer()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}

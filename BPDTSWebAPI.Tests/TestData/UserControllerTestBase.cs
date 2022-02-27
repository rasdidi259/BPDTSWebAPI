using BPDTSWebAPI.Entities;
using BPDTSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Tests.TestData
{
   public static class UserControllerTestBase
    {
        public static List<UserByCity> GetUserByCities() => new()
            {
                new UserByCity()
                {
                    Id= 266,
                    First_Name= "Ancell",
                    Last_Name= "Garnsworthy",
                    Email= "agarnsworthy7d@seattletimes.com",
                    IP_Address= "67.4.69.137",
                    Latitude= 51.6553959,
                    Longitude= 0.0572553
                },

                new UserByCity()
                {
                    Id= 554,
                    First_Name= "Phyllys",
                    Last_Name= "Hebbs",
                    Email= "phebbsfd@umn.edu",
                    IP_Address= "100.89.186.13",
                    Latitude= 51.5489435,
                    Longitude= 0.3860497
                },

                new UserByCity()
                {
                    Id= 322,
                    First_Name= "Hugo",
                    Last_Name= "Lynd",
                    Email= "hlynd8x@merriam-webster.com",
                    IP_Address= "109.0.153.166",
                    Latitude= 51.6710832,
                    Longitude= 0.8078532
                }
            };

        public static List<UserByCityDTO> GetUserByCityDTOs() =>new()
        {
            new UserByCityDTO()
            {
                Id = 266,
                First_Name = "Ancell",
                Last_Name = "Garnsworthy",
                Email = "agarnsworthy7d@seattletimes.com",
                IP_Address = "67.4.69.137",
                Latitude = 51.6553959,
                Longitude = 0.0572553
            },

            new UserByCityDTO()
            {
                Id = 554,
                First_Name = "Mechelle",
                Last_Name = "Boam",
                Email = "mboam3q@thetimes.co.uk",
                IP_Address = "113.71.242.187",
                Latitude = -6.5115909,
                Longitude = 105.652983
            },

            new UserByCityDTO()
            {
                Id = 322,
                First_Name = "Hugo",
                Last_Name = "Lynd",
                Email = "hlynd8x@merriam-webster.com",
                IP_Address = "109.0.153.166",
                Latitude = 51.6710832,
                Longitude = 0.8078532
            }            
        };



        public static List<User> GetUsers() => new()
        {
            new User()
            {
                Id = 266,
                First_Name = "Ancell",
                Last_Name = "Garnsworthy",
                Email = "agarnsworthy7d@seattletimes.com",
                IP_Address = "67.4.69.137",
                Latitude = 51.6553959,
                Longitude = 0.0572553,
                City= "L’govskiy"
            }
        };

        public static List<UserDTO> GetUserDTOs() => new()
        {
            new UserDTO()
            {
                Id = 266,
                First_Name = "Ancell",
                Last_Name = "Garnsworthy",
                Email = "agarnsworthy7d@seattletimes.com",
                IP_Address = "67.4.69.137",
                Latitude = 51.6553959,
                Longitude = 0.0572553,
                City= "L’govskiy"
            }
        };


        public static User GetUser() => new()
        {
            Id = 266,
            First_Name = "Ancell",
            Last_Name = "Garnsworthy",
            Email = "agarnsworthy7d@seattletimes.com",
            IP_Address = "67.4.69.137",
            Latitude = 51.6553959,
            Longitude = 0.0572553,
            City = "L’govskiy"
    };

        public static UserDTO GetUserDTO() => new()
        {
            Id = 266,
            First_Name = "Ancell",
            Last_Name = "Garnsworthy",
            Email = "agarnsworthy7d@seattletimes.com",
            IP_Address = "67.4.69.137",
            Latitude = 51.6553959,
            Longitude = 0.0572553,
            City = "L’govskiy"
        };
    }
}

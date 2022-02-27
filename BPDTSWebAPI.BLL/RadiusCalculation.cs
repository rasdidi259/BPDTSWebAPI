using BPDTSWebAPI.Entities;
using Marknotgeorge.GeodesicLibrary;
using System;
using System.Collections.Generic;

namespace BPDTSWebAPI.BLL
{
    public static class RadiusCalculation
    {
        // 51 deg 30 min 26 sec N
        private readonly static double londonLatitude = 51 + (30 / 60.0) + (26 / 60.0 / 60.0);

        // 0 deg 7 min 39 sec W
        private static readonly double londonLongitude = 0 - (7 / 60.0) - (39 / 60.0 / 60.0);


        public static List<UserByCity> GetUserByCordinates(List<UserByCity> userByCities)
        {
            List<UserByCity>  londonUsers = new List<UserByCity>();

            foreach (var item in userByCities)
            {
                Position sourcePosition = new(item.Latitude, item.Longitude);
                Position londonPosition = new(londonLatitude, londonLongitude);

               var distancaInMiles =  sourcePosition.DistanceTo(londonPosition, UnitsNet.Units.LengthUnit.Mile); // calculate the distance in miles

                if (distancaInMiles <= 50)
                {
                    londonUsers.Add( 
                        new UserByCity()
                        {
                            Id = item.Id,
                            First_Name = item.First_Name,
                            Last_Name = item.Last_Name,
                            Email = item.Email,
                            IP_Address = item.IP_Address,
                            Latitude = item.Latitude,
                            Longitude = item.Longitude
                        });
                }
            }
            return londonUsers;
        }
    }
}

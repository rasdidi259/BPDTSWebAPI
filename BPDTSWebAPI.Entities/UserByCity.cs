namespace BPDTSWebAPI.Entities
{
    public class UserByCity
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string IP_Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
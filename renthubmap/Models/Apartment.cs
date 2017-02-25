using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace renthubmap.Models
{
    public class Apartment
    {
        public Apartment()
        {
        }
        public int apartmentID { get; set; }
        public string apartmentName { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public string sublink { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }

        public string innerHTML_info { get; set; }
        public string innerHTML_price { get; set; }
        public string innerHTML_room { get; set; }
        public string innerHTML_image { get; set; }
    }
}
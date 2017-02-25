using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace renthubmap.Models
{
    public class DTOContainer
    {
        public int ID { get; set; }
        private List<Apartment> _appartment;
        public string AbsolutePath { get; set; }
        public string link { get; set; }
        public string linkName { get; set; }
        public string resuorce { get; set; }

        public List<Apartment> appartment {
            get {
                if(_appartment == null)
                {
                    _appartment = new List<Apartment>();
                    return _appartment;
                }
                else
                {
                    return _appartment;
                }
            }
            set
            {
                _appartment = value;
            }
        }
    }
}
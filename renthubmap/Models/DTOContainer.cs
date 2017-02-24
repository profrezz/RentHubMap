using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace renthubmap.Models
{
    public class DTOContainer
    {
        private List<Apartment> _appartment;

        public string link { get; set; }
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
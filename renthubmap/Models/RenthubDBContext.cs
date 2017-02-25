using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace renthubmap.Models
{
    public class RenthubDBContext : DbContext
    {
        public DbSet<Apartment> apartments { get; set; }
        public DbSet<ApartmentList> apartmentList { get; set; }
        public DbSet<DTOContainer> DTOContainers { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models
{
    public class DvdLibraryEntities : DbContext
    {
        public DvdLibraryEntities()
            : base("DvdLibraryEF")
        {
        }
        public DbSet<Dvd> Dvds { get; set; }
    }
}
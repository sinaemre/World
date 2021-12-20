using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dunya.Data
{
    public class DunyaContext : DbContext
    {
        public DbSet<Yer> Yerler { get; set; }
    }
}

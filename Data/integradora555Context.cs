using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using integradora555.Models;

    public class integradora555Context : DbContext
    {
        public integradora555Context (DbContextOptions<integradora555Context> options)
            : base(options)
        {
        }

        public DbSet<integradora555.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<integradora555.Models.Casa>? Casa { get; set; }

        public DbSet<integradora555.Models.Alquiler>? Alquiler { get; set; }

        public DbSet<integradora555.Models.Devolucion>? Devolucion { get; set; }
    }

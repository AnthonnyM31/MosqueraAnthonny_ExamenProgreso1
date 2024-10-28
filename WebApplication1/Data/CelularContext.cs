using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

    public class CelularContext : DbContext
    {
        public CelularContext (DbContextOptions<CelularContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Celular> Celular { get; set; } = default!;
    }

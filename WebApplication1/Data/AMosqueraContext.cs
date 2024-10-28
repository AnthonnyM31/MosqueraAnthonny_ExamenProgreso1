using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

    public class AMosqueraContext : DbContext
    {
        public AMosqueraContext (DbContextOptions<AMosqueraContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.AMosquera> AMosquera { get; set; } = default!;
    }

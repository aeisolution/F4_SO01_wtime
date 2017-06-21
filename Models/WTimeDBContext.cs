using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace wtime.Models
{
    public class WTimeDBContext : DbContext
    {
        public virtual DbSet<Operatore> Operatori { get; set; }
        public virtual DbSet<FasciaOraria> FasceOrarie { get; set; }

        public virtual DbSet<ProfiloOrario> ProfiliOrari { get; set; }
    }
}
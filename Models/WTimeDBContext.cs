using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace wtime.Models
{
    public class WTimeDBContext : DbContext
    {
        public WTimeDBContext() : base("DefaultConnection")
        {
        }

        public virtual DbSet<Operatore> Operatori { get; set; }
        public virtual DbSet<Richiesta> Richieste { get; set; }

        public virtual DbSet<ProfiloOrario> ProfiliOrari { get; set; }
        public virtual DbSet<FasciaOraria> FasceOrarie { get; set; }

        //Parametri
        public virtual DbSet<TipoRichiesta> TipoRichieste { get; set; }
        public virtual DbSet<TipoStatus> TipoStatus { get; set; }

    }
}
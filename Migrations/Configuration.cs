namespace wtime.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<wtime.Models.WTimeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(wtime.Models.WTimeDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ProfiliOrari.AddOrUpdate(
                p => p.IdProfiloOrario,
                    new ProfiloOrario { IdProfiloOrario = 1, Nome = "FULL Time", NumeroOre = 8},
                    new ProfiloOrario { IdProfiloOrario = 2, Nome = "PART Time 50%", NumeroOre = 4 },
                    new ProfiloOrario { IdProfiloOrario = 3, Nome = "PART Time 60%", NumeroOre = 5 }
                );

            context.FasceOrarie.AddOrUpdate(
                f => f.Codice,
                new FasciaOraria { Codice = "FT_A",
                                   B1_Inizio_Ora = 7, B1_Inizio_Minuti = 0,
                                   B1_Fine_Ora = 12, B1_Fine_Minuti = 0,
                                   B2_Inizio_Ora = 13, B2_Inizio_Minuti = 0,
                                   B2_Fine_Ora = 17, B2_Fine_Minuti = 0 },
                new FasciaOraria { Codice = "FT_B",
                                    B1_Inizio_Ora = 8, B1_Inizio_Minuti = 0,
                                    B1_Fine_Ora = 12, B1_Fine_Minuti = 0,
                                    B2_Inizio_Ora = 12, B2_Inizio_Minuti = 30,
                                    B2_Fine_Ora = 16, B2_Fine_Minuti = 30
                });

            context.TipoRichieste.AddOrUpdate(
                tr => tr.IdTipoRichiesta,
                new TipoRichiesta { IdTipoRichiesta = 1, Nome = "Permesso", Giornaliero = true },
                new TipoRichiesta { IdTipoRichiesta = 2, Nome = "Ferie", Giornaliero = false }
                );

            context.TipoStatus.AddOrUpdate(
                ts => ts.IdTipoStatus,
                new TipoStatus { IdTipoStatus = 1, Nome = "Aperta" },
                new TipoStatus { IdTipoStatus = 2, Nome = "Accettata" },
                new TipoStatus { IdTipoStatus = 3, Nome = "Rifiutata" }
                );
        }
    }
}

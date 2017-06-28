namespace wtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class richiesta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Richiestas",
                c => new
                    {
                        IdRichiesta = c.Int(nullable: false, identity: true),
                        IdOperatore = c.Int(nullable: false),
                        DataInizio = c.DateTime(nullable: false),
                        DataFine = c.DateTime(nullable: false),
                        Giornaliera = c.Boolean(nullable: false),
                        OraInizio = c.Int(),
                        MinutiInizio = c.Int(),
                        OraFine = c.Int(),
                        MinutiFine = c.Int(),
                        IdTipoStatus = c.Int(nullable: false),
                        DataStatus = c.DateTime(nullable: false),
                        Note = c.String(),
                        UsernameValidatore = c.String(),
                    })
                .PrimaryKey(t => t.IdRichiesta)
                .ForeignKey("dbo.Operatores", t => t.IdOperatore, cascadeDelete: true)
                .ForeignKey("dbo.TipoStatus", t => t.IdTipoStatus, cascadeDelete: true)
                .Index(t => t.IdOperatore)
                .Index(t => t.IdTipoStatus);
            
            CreateTable(
                "dbo.TipoStatus",
                c => new
                    {
                        IdTipoStatus = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdTipoStatus);
            
            CreateTable(
                "dbo.TipoRichiestas",
                c => new
                    {
                        IdTipoRichiesta = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Giornaliero = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdTipoRichiesta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Richiestas", "IdTipoStatus", "dbo.TipoStatus");
            DropForeignKey("dbo.Richiestas", "IdOperatore", "dbo.Operatores");
            DropIndex("dbo.Richiestas", new[] { "IdTipoStatus" });
            DropIndex("dbo.Richiestas", new[] { "IdOperatore" });
            DropTable("dbo.TipoRichiestas");
            DropTable("dbo.TipoStatus");
            DropTable("dbo.Richiestas");
        }
    }
}

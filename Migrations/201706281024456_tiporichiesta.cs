namespace wtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tiporichiesta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Richiestas", "IdTipoRichiesta", c => c.Int(nullable: false));
            CreateIndex("dbo.Richiestas", "IdTipoRichiesta");
            AddForeignKey("dbo.Richiestas", "IdTipoRichiesta", "dbo.TipoRichiestas", "IdTipoRichiesta", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Richiestas", "IdTipoRichiesta", "dbo.TipoRichiestas");
            DropIndex("dbo.Richiestas", new[] { "IdTipoRichiesta" });
            DropColumn("dbo.Richiestas", "IdTipoRichiesta");
        }
    }
}

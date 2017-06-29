namespace wtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class richiesta_datafine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Richiestas", "DataFine", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Richiestas", "DataFine", c => c.DateTime(nullable: false));
        }
    }
}

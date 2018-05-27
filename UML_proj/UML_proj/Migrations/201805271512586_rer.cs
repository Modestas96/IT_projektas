namespace UML_proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rer : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AddColumn("dbo.Newsletter_entry", "receit_forms", c => c.String());
        }
    }
}

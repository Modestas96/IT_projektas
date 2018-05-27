namespace UML_proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_recei_forms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Newsletter_entry", "receit_forms", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Newsletter_entry", "receit_forms");
        }
    }
}

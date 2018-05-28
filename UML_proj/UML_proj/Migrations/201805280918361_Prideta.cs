namespace UML_proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prideta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Person", "email", c => c.String(maxLength: 225, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Person", "email", c => c.String(maxLength: 255, unicode: false));
        }
    }
}

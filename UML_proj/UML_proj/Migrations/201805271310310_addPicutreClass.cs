namespace UML_proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPicutreClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Unclassified_pictures", "picture_class", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Unclassified_pictures", "picture_class");
        }
    }
}

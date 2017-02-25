namespace renthubmap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjusttableApartmentList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApartmentLists", "total", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApartmentLists", "total");
        }
    }
}

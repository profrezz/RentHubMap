namespace renthubmap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApartmentLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        link = c.String(),
                        linkName = c.String(),
                        zone_id = c.Int(nullable: false),
                        resuorce = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Apartments", "DTOContainer_ID", "dbo.DTOContainers");
            DropIndex("dbo.Apartments", new[] { "DTOContainer_ID" });
            DropTable("dbo.DTOContainers");
            DropTable("dbo.Apartments");
            DropTable("dbo.ApartmentLists");
        }
    }
}

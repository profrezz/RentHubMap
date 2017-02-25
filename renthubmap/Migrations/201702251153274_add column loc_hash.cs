namespace renthubmap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnloc_hash : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "loc_hash", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Apartments", "loc_hash");
        }
    }
}

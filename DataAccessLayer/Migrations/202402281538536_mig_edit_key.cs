namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_edit_key : DbMigration
    {
        public override void Up()
        {
      
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "AboutId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Contacts");
            DropColumn("dbo.Contacts", "ContactID");
            AddPrimaryKey("dbo.Contacts", "AboutId");
        }
    }
}

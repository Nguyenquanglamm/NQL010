namespace Nguyenquanglam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class acc : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Accs", newName: "Accounts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Accounts", newName: "Accs");
        }
    }
}

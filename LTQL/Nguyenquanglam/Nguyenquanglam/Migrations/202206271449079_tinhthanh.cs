namespace Nguyenquanglam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tinhthanh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tinhthanhs",
                c => new
                    {
                        MaTinhThanh = c.Int(nullable: false, identity: true),
                        TenTinhThanh = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaTinhThanh);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tinhthanhs");
        }
    }
}

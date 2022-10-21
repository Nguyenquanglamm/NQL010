namespace LTQL_17210500100.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nhacungcap : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhaCungCaps",
                c => new
                    {
                        MaNhaCungCap = c.Int(nullable: false, identity: true),
                        TenNhaCungCap = c.String(),
                    })
                .PrimaryKey(t => t.MaNhaCungCap);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NhaCungCaps");
        }
    }
}

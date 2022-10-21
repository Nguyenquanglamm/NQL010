namespace Nguyenquanglam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nhanvien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaNhanVien = c.String(nullable: false, maxLength: 128),
                        TenNhanVien = c.String(),
                        MaTinhThanh = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaNhanVien)
                .ForeignKey("dbo.Tinhthanhs", t => t.MaTinhThanh, cascadeDelete: true)
                .Index(t => t.MaTinhThanh);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanViens", "MaTinhThanh", "dbo.Tinhthanhs");
            DropIndex("dbo.NhanViens", new[] { "MaTinhThanh" });
            DropTable("dbo.NhanViens");
        }
    }
}

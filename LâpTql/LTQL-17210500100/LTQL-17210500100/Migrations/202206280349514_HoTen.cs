namespace LTQL_17210500100.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HoTen : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Sanphams");
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        userName = c.String(nullable: false, maxLength: 128),
                        passWord = c.String(),
                    })
                .PrimaryKey(t => t.userName);
            
            CreateTable(
                "dbo.NguyenQuanglams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Sanphams", "NhaCungCap_MaNhaCungCap", c => c.Int());
            AlterColumn("dbo.NhaCungCaps", "TenNhaCungCap", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Sanphams", "MaSanPham", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Sanphams", "MaSanpham");
            CreateIndex("dbo.Sanphams", "NhaCungCap_MaNhaCungCap");
            AddForeignKey("dbo.Sanphams", "NhaCungCap_MaNhaCungCap", "dbo.NhaCungCaps", "MaNhaCungCap");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sanphams", "NhaCungCap_MaNhaCungCap", "dbo.NhaCungCaps");
            DropIndex("dbo.Sanphams", new[] { "NhaCungCap_MaNhaCungCap" });
            DropPrimaryKey("dbo.Sanphams");
            AlterColumn("dbo.Sanphams", "MaSanPham", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.NhaCungCaps", "TenNhaCungCap", c => c.String());
            DropColumn("dbo.Sanphams", "NhaCungCap_MaNhaCungCap");
            DropTable("dbo.NguyenQuanglams");
            DropTable("dbo.Accounts");
            AddPrimaryKey("dbo.Sanphams", "MaSanpham");
        }
    }
}

namespace NQLBaiTapLon010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Luongs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDNhanVien = c.String(maxLength: 128),
                        Thang = c.DateTime(nullable: false),
                        LuongNgay = c.Single(nullable: false),
                        NgayCong = c.Single(nullable: false),
                        TamUng = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NhanViens", t => t.IDNhanVien)
                .Index(t => t.IDNhanVien);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Luongs", "IDNhanVien", "dbo.NhanViens");
            DropIndex("dbo.Luongs", new[] { "IDNhanVien" });
            DropTable("dbo.Luongs");
        }
    }
}

namespace NQLBaiTapLon010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hopdong : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hopdongs",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        IDnhanvien = c.String(maxLength: 128),
                        Ngaykyket = c.DateTime(nullable: false),
                        Thoihanhopdong = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NhanViens", t => t.IDnhanvien)
                .Index(t => t.IDnhanvien);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hopdongs", "IDnhanvien", "dbo.NhanViens");
            DropIndex("dbo.Hopdongs", new[] { "IDnhanvien" });
            DropTable("dbo.Hopdongs");
        }
    }
}

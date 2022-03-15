namespace NQLBaiTapLon010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanViens", "IDchucvu", c => c.String(maxLength: 128));
            AddColumn("dbo.NhanViens", "IDphongban", c => c.String(maxLength: 128));
            AddColumn("dbo.Phongbans", "Sdtphongban", c => c.String());
            CreateIndex("dbo.NhanViens", "IDchucvu");
            CreateIndex("dbo.NhanViens", "IDphongban");
            AddForeignKey("dbo.NhanViens", "IDchucvu", "dbo.Chucvus", "IDchucvu");
            AddForeignKey("dbo.NhanViens", "IDphongban", "dbo.Phongbans", "IDphongban");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanViens", "IDphongban", "dbo.Phongbans");
            DropForeignKey("dbo.NhanViens", "IDchucvu", "dbo.Chucvus");
            DropIndex("dbo.NhanViens", new[] { "IDphongban" });
            DropIndex("dbo.NhanViens", new[] { "IDchucvu" });
            DropColumn("dbo.Phongbans", "Sdtphongban");
            DropColumn("dbo.NhanViens", "IDphongban");
            DropColumn("dbo.NhanViens", "IDchucvu");
        }
    }
}

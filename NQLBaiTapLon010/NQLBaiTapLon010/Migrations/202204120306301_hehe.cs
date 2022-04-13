namespace NQLBaiTapLon010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hehe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanViens", "Tennhanvien", c => c.String(nullable: false));
            AlterColumn("dbo.NhanViens", "Ngaysinhnhanvien", c => c.String(nullable: false));
            AlterColumn("dbo.NhanViens", "SDTnhanvien", c => c.String(nullable: false));
            AlterColumn("dbo.NhanViens", "Gioitinhnhanvien", c => c.String(nullable: false));
            AlterColumn("dbo.NhanViens", "Diachinhanvien", c => c.String(nullable: false));
            AlterColumn("dbo.NhanViens", "CCCDnhanvien", c => c.String(nullable: false));
            AlterColumn("dbo.Dangkys", "Ten", c => c.String(nullable: false));
            AlterColumn("dbo.Dangkys", "SDT", c => c.String(nullable: false));
            AlterColumn("dbo.Dangkys", "Gmail", c => c.String(nullable: false));
            AlterColumn("dbo.Hopdongs", "Thoihanhopdong", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hopdongs", "Thoihanhopdong", c => c.String());
            AlterColumn("dbo.Dangkys", "Gmail", c => c.String());
            AlterColumn("dbo.Dangkys", "SDT", c => c.String());
            AlterColumn("dbo.Dangkys", "Ten", c => c.String());
            AlterColumn("dbo.NhanViens", "CCCDnhanvien", c => c.String());
            AlterColumn("dbo.NhanViens", "Diachinhanvien", c => c.String());
            AlterColumn("dbo.NhanViens", "Gioitinhnhanvien", c => c.String());
            AlterColumn("dbo.NhanViens", "SDTnhanvien", c => c.String());
            AlterColumn("dbo.NhanViens", "Ngaysinhnhanvien", c => c.String());
            AlterColumn("dbo.NhanViens", "Tennhanvien", c => c.String());
        }
    }
}

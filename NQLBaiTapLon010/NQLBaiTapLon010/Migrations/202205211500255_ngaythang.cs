namespace NQLBaiTapLon010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ngaythang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanViens", "Ngaysinhnhanvien", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanViens", "Ngaysinhnhanvien", c => c.String(nullable: false));
        }
    }
}

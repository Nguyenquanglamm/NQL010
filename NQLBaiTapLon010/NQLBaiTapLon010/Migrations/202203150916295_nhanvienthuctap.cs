namespace NQLBaiTapLon010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nhanvienthuctap : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanViens", "Thoigianthuctap", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanViens", "Thoigianthuctap");
        }
    }
}

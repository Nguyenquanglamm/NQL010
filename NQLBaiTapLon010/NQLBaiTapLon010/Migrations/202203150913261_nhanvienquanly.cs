namespace NQLBaiTapLon010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nhanvienquanly : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanViens", "note", c => c.String());
            AddColumn("dbo.NhanViens", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanViens", "Discriminator");
            DropColumn("dbo.NhanViens", "note");
        }
    }
}

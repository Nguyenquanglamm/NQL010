namespace NQLBaiTapLon010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nhanvien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        IDnhanvien = c.String(nullable: false, maxLength: 128),
                        Tennhanvien = c.String(),
                        Ngaysinhnhanvien = c.String(),
                        SDTnhanvien = c.String(),
                        Gioitinhnhanvien = c.String(),
                        Diachinhanvien = c.String(),
                        CCCDnhanvien = c.String(),
                    })
                .PrimaryKey(t => t.IDnhanvien);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NhanViens");
        }
    }
}

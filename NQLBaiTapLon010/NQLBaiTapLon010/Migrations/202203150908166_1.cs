namespace NQLBaiTapLon010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dangkys",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Ten = c.String(),
                        SDT = c.String(),
                        Gioitinh = c.String(),
                        Ngaysinh = c.String(),
                        Quequan = c.String(),
                        Trinhdo = c.String(),
                        Gmail = c.String(),
                        Vitriungtuyen = c.String(),
                        Kinhnghiem = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dangkys");
        }
    }
}

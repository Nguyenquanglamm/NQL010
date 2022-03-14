namespace NQLBaiTapLon010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phongban : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phongbans",
                c => new
                    {
                        IDphongban = c.String(nullable: false, maxLength: 128),
                        Tenphongban = c.String(),
                    })
                .PrimaryKey(t => t.IDphongban);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Phongbans");
        }
    }
}

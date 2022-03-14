namespace NQLBaiTapLon010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chucvu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chucvus",
                c => new
                    {
                        IDchucvu = c.String(nullable: false, maxLength: 128),
                        Tenchucvu = c.String(),
                    })
                .PrimaryKey(t => t.IDchucvu);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Chucvus");
        }
    }
}

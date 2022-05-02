namespace NQLBaiThucHanh010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class account : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accs",
                c => new
                    {
                        UseName = c.String(nullable: false, maxLength: 128),
                        PassWord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UseName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accs");
        }
    }
}

namespace LTQL_17210500100.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sanpham1r : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sanphams",
                c => new
                    {
                        MaSanpham = c.String(nullable: false, maxLength: 128),
                        TenSanpham = c.String(),
                    })
                .PrimaryKey(t => t.MaSanpham);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sanphams");
        }
    }
}

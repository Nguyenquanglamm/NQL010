namespace NQLBaiThucHanh010.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _124 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        PersonID = c.String(nullable: false, maxLength: 128),
                        PersonName = c.String(),
                    })
                .PrimaryKey(t => t.PersonID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Persons");
        }
    }
}

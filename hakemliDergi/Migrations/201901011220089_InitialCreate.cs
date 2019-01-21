namespace prj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Magazines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MagazineReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        MagazineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Magazines", t => t.MagazineId, cascadeDelete: true)
                .Index(t => t.MagazineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MagazineReviews", "MagazineId", "dbo.Magazines");
            DropIndex("dbo.MagazineReviews", new[] { "MagazineId" });
            DropTable("dbo.MagazineReviews");
            DropTable("dbo.Magazines");
        }
    }
}

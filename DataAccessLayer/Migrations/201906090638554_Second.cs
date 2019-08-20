namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileStorages",
                c => new
                    {
                        FileStorageId = c.Guid(nullable: false),
                        FileName = c.String(),
                        FileContentType = c.String(),
                        FileData = c.Binary(),
                    })
                .PrimaryKey(t => t.FileStorageId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        StorageId = c.Guid(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        StorageStatus = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        FileStorageId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.StorageId)
                .ForeignKey("dbo.FileStorages", t => t.FileStorageId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FileStorageId);
            
            AddColumn("dbo.Targets", "FileStorageId", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "FileStorageId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Users", "FileStorageId");
            CreateIndex("dbo.Targets", "FileStorageId");
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "FileStorageId", "dbo.FileStorages");
            DropForeignKey("dbo.Targets", "FileStorageId", "dbo.FileStorages");
            DropForeignKey("dbo.Storages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Storages", "FileStorageId", "dbo.FileStorages");
            DropIndex("dbo.Targets", new[] { "FileStorageId" });
            DropIndex("dbo.Users", new[] { "FileStorageId" });
            DropIndex("dbo.Storages", new[] { "FileStorageId" });
            DropIndex("dbo.Storages", new[] { "UserId" });
            DropColumn("dbo.Users", "FileStorageId");
            DropColumn("dbo.Targets", "FileStorageId");
            DropTable("dbo.Storages");
            DropTable("dbo.FileStorages");
        }
    }
}

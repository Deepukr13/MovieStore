namespace ASPNETIdentity_GoogleAuthenticator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audits",
                c => new
                    {
                        AuditID = c.Guid(nullable: false),
                        UserName = c.String(),
                        IPAddress = c.String(),
                        AreaAccessed = c.String(),
                        TimeAccessed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuditID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Audits");
        }
    }
}

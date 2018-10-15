namespace Gamify.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDrvingLicenseToCountryofResidence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CountryOfResidence", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.AspNetUsers", "CountryOfResidence");
        }
    }
}

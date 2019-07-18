namespace HospitalMgtSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class formatChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "JoiningDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "JoiningDate", c => c.DateTime(nullable: false));
        }
    }
}

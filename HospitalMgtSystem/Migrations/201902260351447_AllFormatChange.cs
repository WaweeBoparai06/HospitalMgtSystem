namespace HospitalMgtSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllFormatChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DayCares", "VisitTime", c => c.String());
            AlterColumn("dbo.OPDRegistrations", "DateOfRegister", c => c.String());
            AlterColumn("dbo.Patients", "DateOfRegister", c => c.String());
            AlterColumn("dbo.PatientAdmissions", "DateOfAdmission", c => c.String());
            AlterColumn("dbo.PatientAdmissions", "DateOfDischarge", c => c.String());
            AlterColumn("dbo.Nurses", "JoiningDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nurses", "JoiningDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientAdmissions", "DateOfDischarge", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientAdmissions", "DateOfAdmission", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Patients", "DateOfRegister", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OPDRegistrations", "DateOfRegister", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DayCares", "VisitTime", c => c.DateTime(nullable: false));
        }
    }
}

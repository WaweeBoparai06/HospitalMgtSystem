namespace HospitalMgtSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdmissionTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DayCares",
                c => new
                    {
                        DayCareId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        VisitTime = c.DateTime(nullable: false),
                        NurseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DayCareId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Nurses", t => t.NurseId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.NurseId);
            
            CreateTable(
                "dbo.PatientAdmissions",
                c => new
                    {
                        PatientAdmissionId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        RoomNo = c.Int(nullable: false),
                        DateOfAdmission = c.DateTime(nullable: false),
                        DateOfDischarge = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        RemarkOfDischarge = c.String(),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientAdmissionId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DayCares", "NurseId", "dbo.Nurses");
            DropForeignKey("dbo.PatientAdmissions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientAdmissions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.DayCares", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.DayCares", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.PatientAdmissions", new[] { "DoctorId" });
            DropIndex("dbo.PatientAdmissions", new[] { "PatientId" });
            DropIndex("dbo.DayCares", new[] { "NurseId" });
            DropIndex("dbo.DayCares", new[] { "DoctorId" });
            DropIndex("dbo.DayCares", new[] { "PatientId" });
            DropTable("dbo.PatientAdmissions");
            DropTable("dbo.DayCares");
        }
    }
}

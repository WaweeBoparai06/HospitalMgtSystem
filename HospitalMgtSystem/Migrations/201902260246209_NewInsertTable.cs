namespace HospitalMgtSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewInsertTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OPDRegistrations",
                c => new
                    {
                        OPDId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        DateOfRegister = c.DateTime(nullable: false),
                        Problem = c.String(),
                        RoomNo = c.Int(nullable: false),
                        TokenNo = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OPDId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                        Age = c.Int(nullable: false),
                        DateOfRegister = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Status = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OPDRegistrations", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.OPDRegistrations", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.OPDRegistrations", new[] { "DoctorId" });
            DropIndex("dbo.OPDRegistrations", new[] { "PatientId" });
            DropTable("dbo.Patients");
            DropTable("dbo.OPDRegistrations");
        }
    }
}

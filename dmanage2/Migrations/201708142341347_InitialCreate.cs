namespace dmanage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoursesModels",
                c => new
                    {
                        CourseId = c.Guid(nullable: false),
                        CourseName = c.String(nullable: false, maxLength: 120),
                        DepartmentId = c.Guid(nullable: false),
                        coursetype = c.String(nullable: false),
                        CourseIdfk = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.CoursesModels", t => t.CourseIdfk)
                .ForeignKey("dbo.DepartmentsModels", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseIdfk);
            
            CreateTable(
                "dbo.DepartmentsModels",
                c => new
                    {
                        DepartmentId = c.Guid(nullable: false),
                        DepartmentName = c.String(nullable: false, maxLength: 100),
                        HOD = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.CourseTypesModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        coursename = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FacultiesModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FacultyName = c.String(nullable: false, maxLength: 100),
                        DepartmentsId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DepartmentsModels", t => t.DepartmentsId, cascadeDelete: true)
                .Index(t => t.DepartmentsId);
            
            CreateTable(
                "dbo.StudentsModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RollNumber = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        DepartmentsModel = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.RollNumber })
                .ForeignKey("dbo.DepartmentsModels", t => t.DepartmentsModel, cascadeDelete: true)
                .Index(t => t.DepartmentsModel);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentsModels", "DepartmentsModel", "dbo.DepartmentsModels");
            DropForeignKey("dbo.FacultiesModels", "DepartmentsId", "dbo.DepartmentsModels");
            DropForeignKey("dbo.CoursesModels", "DepartmentId", "dbo.DepartmentsModels");
            DropForeignKey("dbo.CoursesModels", "CourseIdfk", "dbo.CoursesModels");
            DropIndex("dbo.StudentsModels", new[] { "DepartmentsModel" });
            DropIndex("dbo.FacultiesModels", new[] { "DepartmentsId" });
            DropIndex("dbo.CoursesModels", new[] { "CourseIdfk" });
            DropIndex("dbo.CoursesModels", new[] { "DepartmentId" });
            DropTable("dbo.StudentsModels");
            DropTable("dbo.FacultiesModels");
            DropTable("dbo.CourseTypesModels");
            DropTable("dbo.DepartmentsModels");
            DropTable("dbo.CoursesModels");
        }
    }
}

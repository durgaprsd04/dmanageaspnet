namespace dmanage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CoursesModels", "CourseTypeID", c => c.Guid(nullable: false));
            CreateIndex("dbo.CoursesModels", "CourseTypeID");
            AddForeignKey("dbo.CoursesModels", "CourseTypeID", "dbo.CourseTypesModels", "Id", cascadeDelete: true);
            DropColumn("dbo.CoursesModels", "coursetype");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CoursesModels", "coursetype", c => c.String(nullable: false));
            DropForeignKey("dbo.CoursesModels", "CourseTypeID", "dbo.CourseTypesModels");
            DropIndex("dbo.CoursesModels", new[] { "CourseTypeID" });
            DropColumn("dbo.CoursesModels", "CourseTypeID");
        }
    }
}

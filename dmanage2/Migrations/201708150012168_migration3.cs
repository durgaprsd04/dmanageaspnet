namespace dmanage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CoursesModels", new[] { "CourseIdfk" });
            AlterColumn("dbo.CoursesModels", "CourseIdfk", c => c.Guid());
            CreateIndex("dbo.CoursesModels", "CourseIdfk");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CoursesModels", new[] { "CourseIdfk" });
            AlterColumn("dbo.CoursesModels", "CourseIdfk", c => c.Guid(nullable: false));
            CreateIndex("dbo.CoursesModels", "CourseIdfk");
        }
    }
}

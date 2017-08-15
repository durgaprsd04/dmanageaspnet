using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dmanage2.Models
{
    public class CoursesModel
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        [StringLength(120)]
        public string CourseName { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual DepartmentsModel Department { get; set; }
        [ForeignKey("CourseTypeID")]
        public virtual CourseTypesModel coursetypesmodel { get; set; }
        public Guid CourseTypeID { get; set; }
        [ForeignKey("CourseIdfk")]
        public virtual CoursesModel coursesModel { get; set; }
        public Guid? CourseIdfk { get; set; }
    }

}
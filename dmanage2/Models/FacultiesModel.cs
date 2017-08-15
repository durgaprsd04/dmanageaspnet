using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dmanage2.Models
{
    public class FacultiesModel
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FacultyName { get; set; }
        [ForeignKey("DepartmentsId")]
        public virtual DepartmentsModel Department { get; set; }
        public Guid DepartmentsId { get;set;}
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dmanage2.Models
{
    public class CourseTypesModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string coursename { get; set; }
    }
}
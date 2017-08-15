using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dmanage2.Models
{
    public class DepartmentsModel
    {
     
        [Key]
        public Guid DepartmentId { get; set; }
        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }
        [Required]
        public string HOD { get; set; }
        
    }
}
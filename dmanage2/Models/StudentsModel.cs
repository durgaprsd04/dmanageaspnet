using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dmanage2.Models
{
    public class StudentsModel
    {
        [Key][Column(Order =0)]
        public Guid Id {get;set;}
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Key][Column(Order = 1)]
        [StringLength(100)]
        public string RollNumber { get; set; }
        [ForeignKey("DepartmentsModel")]
        public virtual  DepartmentsModel Department { get; set; }
        public Guid DepartmentsModel { get; set; }

   }
   
   
    }
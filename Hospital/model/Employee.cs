﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.model{
    [Table("EMPLOYEES")]
    public class Employee{
        [Column("EMPLOYEE_ID")]
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
        
        [Column("SVNR", TypeName = "INT")] [Required]
        public int Svnr{ get; set; }

        [Column("FIRST_NAME", TypeName = "VARCHAR(30)")]
        [Required]
        public string FirstName{ get; set; }

        [Column("LAST_NAME", TypeName = "VARCHAR(30)")]
        [Required]
        public string LastName{ get; set; }

        [Column("SALARY", TypeName = "INT")]
        [Required]
        public int Salary{ get; set; }
    }
}
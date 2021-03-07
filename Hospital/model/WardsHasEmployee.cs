using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.model{
    [Table("WARDS_HAS_EMPLOYEES")]
    public class WardsHasEmployee{
        
        [Column("WARD_ID")]
        public int WardId{ get; set; }
        [Column("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }
        
        public Employee Employee{ get; set; }
        public Ward Ward{ get; set; }

        [Required]
        [Column("WORKING_HOURS", TypeName = "INT")]
        public int WorkingHours{ get; set; }
    }
}
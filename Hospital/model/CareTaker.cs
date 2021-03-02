using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.model{
    [Table("CARE_TAKERS")]
    public class CareTaker:Employee{
        [ForeignKey("SUPERVISOR")]
        public CareTaker Supervisor { get; set; }
        
    }
}
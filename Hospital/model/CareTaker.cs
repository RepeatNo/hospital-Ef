using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.model{
    [Table("CARE_TAKERS")]
    public class CareTaker:Employee{

        public CareTaker Superior { get; set; }

        [Column("SUPERIOR_ID")]
        public int? SuperiorId{ get; set; }

    }
}
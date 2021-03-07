using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.model{
    [Table("WARDS")]
    public class Ward{
        [Column("WARD_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        [Column("NAME", TypeName = "VARCHAR(100)")]
        [Required]
        public string Name{ get; set; }

        [Column("CARRYING_CAPACITY", TypeName = "INT")]
        [Required]
        public int CarryingCapacity{ get; set; }

        public Physician Leader{ get; set; }
        
        [ForeignKey("HOSPITAL_FACILITY_ID")] 
        public HospitalFacility HospitalFacility_ID{ get; set; }
    }
}
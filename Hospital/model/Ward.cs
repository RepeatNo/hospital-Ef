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

        [Column("LEADER_ID")]
        public int? LeaderId{ get; set; }

        public HospitalFacility HospitalFacility{ get; set; }
        [Column("FACILITY_ID")]
        public int FacilityId{ get; set; }
    }
}
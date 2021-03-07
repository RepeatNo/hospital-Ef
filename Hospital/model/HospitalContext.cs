using Hospital.model;
using Microsoft.EntityFrameworkCore;

namespace Hospital{
    public class HospitalContext: DbContext{
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<CareTaker> CareTakers{ get; set; }
        public DbSet<HospitalFacility> HospitalFacilities{ get; set; }
        public DbSet<WardsHasEmployee> WardsHasEmployees{ get; set; }
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Employee>()
                .HasIndex(d => d.Svnr)
                .IsUnique();

            modelBuilder.Entity<CareTaker>()
                .HasOne(x => x.Supervisor)
                .WithMany();
            
            modelBuilder.Entity<HospitalFacility>()
                .HasIndex(d => d.Name)
                .IsUnique();
            
            modelBuilder.Entity<HospitalFacility>()
                .HasIndex(d => d.PhoneNr)
                .IsUnique();

            modelBuilder.Entity<WardsHasEmployee>()
                .HasKey(l => new{l.EmployeeId, l.WardId});

            modelBuilder.Entity<WardsHasEmployee>()
                .HasOne(l => l.Employee)
                .WithMany()
                .HasForeignKey(l => l.EmployeeId);
            
            modelBuilder.Entity<WardsHasEmployee>()
                .HasOne(l => l.Ward)
                .WithMany()
                .HasForeignKey(l => l.WardId);

            modelBuilder.Entity<Ward>()
                .HasOne(w => w.Leader)
                .WithMany();
        }
    }
}
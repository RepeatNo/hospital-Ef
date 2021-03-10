using System;
using Hospital.model;
using Microsoft.EntityFrameworkCore;

namespace Hospital{
    class Program{
        static void Main(string[] args){
            var contextFactory = new HospitalContextFactory();

            using (var context = contextFactory.CreateDbContext(args))
            {
                context.Database.ExecuteSqlRaw("DELETE FROM WARDS_HAS_EMPLOYEES WHERE 1 = 1");
                context.Database.ExecuteSqlRaw("DELETE FROM WARDS WHERE 1 = 1");
                context.Database.ExecuteSqlRaw("DELETE FROM HOSPITAL_FACILITIES WHERE 1 = 1");
                context.Database.ExecuteSqlRaw("DELETE FROM CARE_TAKERS WHERE SUPERIOR_ID IS NOT NULL");
                context.Database.ExecuteSqlRaw("DELETE FROM CARE_TAKERS WHERE 1 = 1");
                context.Database.ExecuteSqlRaw("DELETE FROM PHYSICIANS WHERE 1 = 1");
                context.Database.ExecuteSqlRaw("DELETE FROM EMPLOYEES WHERE 1 = 1");
      
            }

            CareTaker[] caretakers = new[]
            {
                new CareTaker() {Salary = 2500, Svnr = 1234561, FirstName = "Wladimir", LastName = "Lukaschenko"},
                new CareTaker() {Salary = 2700, Svnr = 1234562, FirstName = "Karl", LastName = "Gustaf"},
                new CareTaker() {Salary = 3000, Svnr = 1234563, FirstName = "Abdul", LastName = "Mehmemt"},
                new CareTaker() {Salary = 2700, Svnr = 1234564, FirstName = "Mohamed", LastName = "Ali"},
                new CareTaker() {Salary = 2800, Svnr = 1234565, FirstName = "Franzeska", LastName = "Huber"},
                new CareTaker() {Salary = 3500, Svnr = 1234567, FirstName = "Khan", LastName = "Abdul"}
            };

            using (var context = contextFactory.CreateDbContext(args))
            {
                caretakers[0].Superior = caretakers[2];
                caretakers[1].Superior = caretakers[2];
                caretakers[3].Superior = caretakers[5];
                caretakers[4].Superior = caretakers[5];

                context.CareTakers.AddRange(caretakers);
                context.SaveChanges();
            }
            
            Physician[] physicians = new Physician[]
            {
                new Physician()
                {
                    Salary = 3800, Svnr = 654321, FirstName = "Tom", LastName = "Lueger",
                    JobSpecialisation = EJobSpecialisation.SURGEON
                },
                new Physician()
                {
                    Salary = 4500, Svnr = 654322, FirstName = "Nikolei", LastName = "Adler",
                    JobSpecialisation = EJobSpecialisation.SURGEON
                },
                new Physician()
                {
                    Salary = 5200, Svnr = 654323, FirstName = "Don Tomasino", LastName = "Ferfeggi",
                    JobSpecialisation = EJobSpecialisation.DIAGNOSTICIAN
                },
                new Physician()
                {
                    Salary = 5500, Svnr = 654324, FirstName = "Tobias Hanelore", LastName = "Huber",
                    JobSpecialisation = EJobSpecialisation.DIAGNOSTICIAN
                },
                new Physician()
                {
                    Salary = 5600, Svnr = 654325, FirstName = "Marco", LastName = "Gangerson",
                    JobSpecialisation = EJobSpecialisation.GENERAL_PROACTITIONER
                },
                new Physician()
                {
                    Salary = 5400, Svnr = 654326, FirstName = "Luca", LastName = "Del Pierro",
                    JobSpecialisation = EJobSpecialisation.GENERAL_PROACTITIONER
                },
                new Physician()
                {
                    Salary = 5700, Svnr = 654327, FirstName = "Joni", LastName = "De Winter",
                    JobSpecialisation = EJobSpecialisation.GENERAL_PROACTITIONER
                }
            };
            
            using (var context = contextFactory.CreateDbContext(args))
            {
                context.Physicians.AddRange(physicians);
                context.SaveChanges();
            }

            HospitalFacility[] hospitalFacilities = new HospitalFacility[]{
                new HospitalFacility(){Name = "LKH Krems", PhoneNr = "02279/8763"},
                new HospitalFacility(){Name = "AKH Wien", PhoneNr = "01/8763"},
                new HospitalFacility(){Name = "LKH Tulln", PhoneNr = "02270/8763"}
            };

            using (var context = contextFactory.CreateDbContext(args))
            {
                context.HospitalFacilities.AddRange(hospitalFacilities);
                context.SaveChanges();
            }
            
            Ward[] wards = new Ward[]
            {
                new Ward()
                {
                    Name = "Abteilung für Chirurgie", CarryingCapacity = 54, Leader = physicians[0],
                    HospitalFacility = hospitalFacilities[0]
                },
                new Ward()
                {
                    Name = "Abteilung für Radiologie", CarryingCapacity = 4, Leader = physicians[1],
                    HospitalFacility = hospitalFacilities[0]
                },
                new Ward()
                {
                    Name = "Interne", CarryingCapacity = 23, Leader = physicians[2],
                    HospitalFacility = hospitalFacilities[0]
                },
                new Ward()
                {
                    Name = "Abteilung für Chirurgie", CarryingCapacity = 100, Leader = physicians[3],
                    HospitalFacility = hospitalFacilities[0]
                },
                new Ward()
                {
                    Name = "Geburtenzentrum", CarryingCapacity = 70, Leader = physicians[4],
                    HospitalFacility = hospitalFacilities[1]
                },
                new Ward()
                {
                    Name = "Unfallabteilung", CarryingCapacity = 120, Leader = physicians[5],
                    HospitalFacility = hospitalFacilities[2]
                }
            };
            
            using(var context = contextFactory.CreateDbContext(args))
            {
                context.UpdateRange(physicians);
                context.UpdateRange(hospitalFacilities);
                context.Wards.AddRange(wards);

                context.SaveChanges();
            }

            WardsHasEmployee[] wardsHasEmployees = new[]{
                new WardsHasEmployee(){Employee = physicians[0], Ward = wards[0], WorkingHours = 40},
                new WardsHasEmployee(){Employee = physicians[1], Ward = wards[0], WorkingHours = 50},
                new WardsHasEmployee(){Employee = physicians[2], Ward = wards[1], WorkingHours = 34},
                new WardsHasEmployee(){Employee = physicians[3], Ward = wards[1], WorkingHours = 45},
                new WardsHasEmployee(){Employee = physicians[4], Ward = wards[2], WorkingHours = 51},
                new WardsHasEmployee(){Employee = physicians[5], Ward = wards[2], WorkingHours = 53},
                new WardsHasEmployee(){Employee = physicians[6], Ward = wards[3], WorkingHours = 45},
                new WardsHasEmployee(){Employee = caretakers[0], Ward = wards[0], WorkingHours = 10},
                new WardsHasEmployee(){Employee = caretakers[0], Ward = wards[1], WorkingHours = 20},
                new WardsHasEmployee(){Employee = caretakers[0], Ward = wards[2], WorkingHours = 15},
                new WardsHasEmployee(){Employee = caretakers[0], Ward = wards[5], WorkingHours = 15},
                new WardsHasEmployee(){Employee = caretakers[1], Ward = wards[0], WorkingHours = 20},
                new WardsHasEmployee(){Employee = caretakers[1], Ward = wards[1], WorkingHours = 5},
                new WardsHasEmployee(){Employee = caretakers[1], Ward = wards[2], WorkingHours = 5},
                new WardsHasEmployee(){Employee = caretakers[1], Ward = wards[3], WorkingHours = 10},
                new WardsHasEmployee(){Employee = caretakers[1], Ward = wards[4], WorkingHours = 5},
                new WardsHasEmployee(){Employee = caretakers[1], Ward = wards[5], WorkingHours = 10},
                new WardsHasEmployee(){Employee = caretakers[2], Ward = wards[0], WorkingHours = 7},
                new WardsHasEmployee(){Employee = caretakers[2], Ward = wards[1], WorkingHours = 7},
                new WardsHasEmployee(){Employee = caretakers[2], Ward = wards[2], WorkingHours = 7},
                new WardsHasEmployee(){Employee = caretakers[2], Ward = wards[4], WorkingHours = 5},
                new WardsHasEmployee(){Employee = caretakers[2], Ward = wards[5], WorkingHours = 10},
                new WardsHasEmployee(){Employee = caretakers[3], Ward = wards[0], WorkingHours = 12},
                new WardsHasEmployee(){Employee = caretakers[3], Ward = wards[1], WorkingHours = 7},
                new WardsHasEmployee(){Employee = caretakers[3], Ward = wards[4], WorkingHours = 13},
                new WardsHasEmployee(){Employee = caretakers[3], Ward = wards[5], WorkingHours = 15},
                new WardsHasEmployee(){Employee = caretakers[4], Ward = wards[0], WorkingHours = 14},
                new WardsHasEmployee(){Employee = caretakers[4], Ward = wards[4], WorkingHours = 21},
                new WardsHasEmployee(){Employee = caretakers[4], Ward = wards[5], WorkingHours = 4},
            };

            using (var context = contextFactory.CreateDbContext(args))
            {
                context.UpdateRange(caretakers);
                context.UpdateRange(physicians);
                context.UpdateRange(wards);
                
                context.WardsHasEmployees.AddRange(wardsHasEmployees);
                context.SaveChanges();
            }
        }
    }
}
using HumanResource.Modals;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<EmployeeModal> Employees {get; set;}
        public DbSet<ProfessionalEmployeeDetailsModal> ProfessionalEmployeeDetails {get; set;}
        public DbSet<EmployeeContactModal> EmployeeContacts {get; set;}
        public DbSet<DocumentModal> Documents {get; set;}
        public DbSet<DepartmentModal> Departments {get; set;}
        public DbSet<StateModal> States {get; set;}
        public DbSet<CityModal> Cities {get; set;}
        public DbSet<OfficeLocationModal> OfficeLocations {get; set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<UserModal>().Property(u => u.userRole).HasConversion<string>();

            modelBuilder.Entity<EmployeeModal>()
            .HasOne(e => e.CityModal)
            .WithMany()
            .HasForeignKey(i => i.CityId)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EmployeeModal>()
            .HasOne(e => e.StateModal)
            .WithMany()
            .HasForeignKey(i => i.StateId)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EmployeeModal>()
            .HasOne(e => e.ProfessionalEmployeeDetailsModal)
            .WithOne(p => p.EmployeeModal)
            .HasForeignKey<ProfessionalEmployeeDetailsModal>(p => p.EmployeeID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeModal>()
            .HasOne(e => e.EmployeeContactModal)
            .WithOne(c => c.EmployeeModal)
            .HasForeignKey<EmployeeContactModal>(c => c.EmployeeID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeModal>()
            .HasMany(e => e.documents)
            .WithOne(d => d.EmployeeModal)
            .HasForeignKey(d => d.EmployeeID)
            .OnDelete(DeleteBehavior.Cascade); 

            // Configuring ProfessionalEmployeeDetailsModal relationships
            modelBuilder.Entity<ProfessionalEmployeeDetailsModal>()
            .HasOne(p => p.DepartmentModal)
            .WithMany()
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ProfessionalEmployeeDetailsModal>()
            .HasOne(p => p.OfficeLocationModal)
            .WithMany()
            .HasForeignKey(p => p.OfficeLocationId)
            .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}

// Employee and City:
// Relationship: Each Employee is associated with one City, and multiple Employees can be in the same City.
// Explanation: Every employee has a city they belong to, but many employees can share the same city.

// Employee and State:
// Relationship: Each Employee is associated with one State, and multiple Employees can be in the same State.
// Explanation: Every employee is linked to a state, but many employees can be in the same state.

// Employee and Professional Details:
// Relationship: Each Employee has one set of Professional Details, and each set of Professional 
// Details belongs to one Employee.
// Explanation: An employee has specific professional details like their job title and 
// department, and these details are unique to that employee.

// Employee and Contact Information:
// Relationship: Each Employee has one set of Contact Information, and each set 
// of Contact Information belongs to one Employee.
// Explanation: Each employee has a single set of contact details (like Slack, Skype),
//  which is unique to that employee.

// Employee and Documents:
// Relationship: An Employee can have many Documents, but each Document belongs to only one Employee.
// Explanation: An employee might have multiple documents (e.g., ID, certificates), but each 
// document is associated with one specific employee.

// Professional Details and Department:
// Relationship: Each set of Professional Details is associated with one Department, 
// and each Department can have many sets of Professional Details.
// Explanation: Each employee’s professional details include their department, and a 
// department can include many employees.

// Professional Details and Office Location:
// Relationship: Each set of Professional Details is associated with one Office Location, 
// and each Office Location can have many sets of Professional Details.
// Explanation: Each employee’s professional details include their office location, and 
// an office location can be assigned to many employees.
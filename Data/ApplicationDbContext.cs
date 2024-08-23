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
        public DbSet<ProjectModal> Projects {get; set;}
        public DbSet<AttendanceModal> Attendances {get; set;}
        public DbSet<JobModal> Jobs {get; set;}
        public DbSet<CandidateModal> Candidates {get; set;}
        public DbSet<PayrollModal> Payrolls {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<UserModal>().Property(u => u.userRole).HasConversion<string>();
            modelBuilder.Entity<AttendanceModal>().Property(u => u.AttendanceStatus).HasConversion<string>();
            modelBuilder.Entity<ProjectModal>().Property(u => u.ProjectStatus).HasConversion<string>();
            modelBuilder.Entity<CandidateModal>().Property(u => u.CandidateStatus).HasConversion<string>();
            modelBuilder.Entity<PayrollModal>().Property(u => u.PayrollStatus).HasConversion<string>();

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

            modelBuilder.Entity<EmployeeModal>()
            .HasMany(ds => ds.attendances)
            .WithOne(d => d.EmployeeModal)
            .HasForeignKey(e => e.EmployeeID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DepartmentModal>()
            .HasMany(x => x.JobModals)
            .WithOne(e => e.DepartmentModal)
            .HasForeignKey(d => d.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobModal>()
            .HasOne(j => j.OfficeLocationModal)  
            .WithMany()                        
            .HasForeignKey(j => j.OfficeLocationId)
            .OnDelete(DeleteBehavior.SetNull);
            // Why: This is typically used when you don't need or want a navigation property on the 
            // other side. For example, if you don't need to access a list of jobs from an OfficeLocationModal, 
            // you omit specifying the model in WithMany().

            modelBuilder.Entity<EmployeeModal>()
            .HasMany(x => x.projects)
            .WithOne(d => d.EmployeeModal)
            .HasForeignKey(d => d.EmployeeID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobModal>()
            .HasMany(x => x.candidateModals)
            .WithOne(i => i.JobModal)
            .HasForeignKey(xi => xi.JobID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PayrollModal>()
            .HasOne(e => e.EmployeeModal)
            .WithOne(x => x.Payrolls)
            .HasForeignKey<PayrollModal>(p => p.EmployeeID)
            .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<EmployeeModal>()
            // .HasOne<PayrollModal>()
            // .WithOne()
            // .HasForeignKey<PayrollModal>(p => p.EmployeeID)
            // .OnDelete(DeleteBehavior.Restrict);


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
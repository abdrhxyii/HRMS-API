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
            public DbSet<ProjectModal> ProjectModals {get; set;}
            public DbSet<AttendanceModal> AttendanceModals {get; set;}
            public DbSet<JobModal> JobModals {get; set;}
            
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                {
                    relationship.DeleteBehavior = DeleteBehavior.Restrict;
                }
                modelBuilder.Entity<UserModal>().Property(u => u.userRole).HasConversion<string>();
                modelBuilder.Entity<AttendanceModal>().Property(u => u.AttendanceStatus).HasConversion<string>();
                modelBuilder.Entity<ProjectModal>().Property(u => u.ProjectStatus).HasConversion<string>();

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
                .HasMany(x => x.JobModals)//one department can have multiple job postings (e.g., the IT department might have several job openings).
                .WithOne(e => e.DepartmentModal)//each job posting belongs to exactly one department, or it can belong to no department
                .HasForeignKey(d => d.DepartmentId)//DepartmentId is the foreign key in JobModal that links it to the DepartmentModal.
                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<JobModal>()
                .HasOne(j => j.OfficeLocationModal)   // A Job has one associated OfficeLocation.
                .WithMany()                           // An OfficeLocation can be associated with many Jobs.
                .HasForeignKey(j => j.OfficeLocationId) // The foreign key in JobModal is OfficeLocationId.
                .OnDelete(DeleteBehavior.SetNull);    // If the OfficeLocation is deleted, set OfficeLocationId in JobModal to null.

            // Why: This is typically used when you don't need or want a navigation property on the 
            // other side. For example, if you don't need to access a list of jobs from an OfficeLocationModal, 
            // you omit specifying the model in WithMany().


            // modelBuilder.Entity<DepartmentModal>()
            // .HasMany(i => i.jobModals)
            // .WithOne(di => di.DepartmentModal)
            // .HasForeignKey(e => e.DepartmentId)


            // modelBuilder.Entity<EmployeeModal>()
            // .HasMany(e => e.projects)
            // .WithOne(d => d.EmployeeModal)
            // .HasForeignKey(e => e.EmployeeID)
            // .OnDelete(DeleteBehavior.Cascade);

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
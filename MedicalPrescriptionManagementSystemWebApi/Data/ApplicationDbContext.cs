using MedicalPrescriptionManagementSystemWebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalPrescriptionManagementSystemWebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Doctor>()
                   .HasKey(d => d.DoctorId);

            builder.Entity<ApplicationUser>()
                        .HasOne<Doctor>(u => u.Doctor)
                        .WithOne(d => d.ApplicationUser)
                        .HasForeignKey<Doctor>(d => d.UserId);

            builder.Entity<Pharmacist>()
                        .HasKey(p => p.PharmacistId);

            builder.Entity<ApplicationUser>()
            .HasOne<Pharmacist>(u => u.Pharmacist)
            .WithOne(p => p.ApplicationUser)
            .HasForeignKey<Pharmacist>(p => p.UserId);

            base.OnModelCreating(builder);
        }
    }
}

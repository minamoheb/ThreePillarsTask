using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project.Core.Entities;
using Project.Core.EntityConfiguration;
using static Project.Core.EntityConfiguration.EntityConfiguration;

namespace Project.Core.Data
{
    public partial class SystemDBContext : IdentityDbContext<ApplicationUser>
    {

      

   
        public SystemDBContext(DbContextOptions<SystemDBContext> options) : base(options)
        {

        }
     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new IdentityEntityConfiguration());
            builder.ApplyConfiguration(new JobTittleEntityConfiguration());
            builder.ApplyConfiguration(new DepartmentEntityConfiguration());
            builder.ApplyConfiguration(new AddressBookEntityConfiguration());


            builder.Entity<AddressBook>(entity =>
            {

           
                entity.HasOne(d => d.JobTittle)
                    .WithMany(p => p.AddressBook)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_AddressBook_JobTittle_JobTittleId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AddressBook)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK_AddressBook_Department_DepartmentId");

            });

        }
        public DbSet<JobTittle> JobTittle { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<AddressBook> AddressBook { get; set; }
        public DbSet<SysError> SysError { get; set; }

    }
}

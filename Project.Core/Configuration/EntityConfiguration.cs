using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Entities;
using System;

namespace Project.Core.EntityConfiguration
{
    public static class EntityConfiguration
    {
        public class IdentityEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Id = "b74ddd12-2390-4390-81c2-db15154843e5",
                    UserName = "admin",
                    NormalizedUserName="admin",
                    Email = "admin@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890"

                };

                PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin123");

                builder.HasData(user);

                //builder.HasData(
                //    new ApplicationUser
                //    {
                //        Id = "b74ddd14-6340-4290-81c2-db16154843e5",
                //        UserName = "Admin",
                //        Email = "admin@gmail.com",
                //        LockoutEnabled = false,
                //        PhoneNumber = "1234567890",
                //    }
                //);



            }
        }
        public class JobTittleEntityConfiguration : IEntityTypeConfiguration<JobTittle>
        {
            public void Configure(EntityTypeBuilder<JobTittle> builder)
            {
                builder.ToTable("JobTittle");
                builder.HasKey(s => s.Id).IsClustered(true);
                builder.HasData(
                new JobTittle
                { Id = 1, JobName = "Junior" },
                new JobTittle
                { Id = 2, JobName = "Senior" }


                );



            }
        }

        public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
        {
            public void Configure(EntityTypeBuilder<Department> builder)
            {
                builder.ToTable("Department");
                builder.HasKey(s => s.Id).IsClustered(true);
                builder.HasData(
                new Department
                { Id = 1, DepartmentName = "Development" },
                new Department
                { Id = 2, DepartmentName = "Support" }



                );



            }
        }
        public class AddressBookEntityConfiguration : IEntityTypeConfiguration<AddressBook>
        {
            public void Configure(EntityTypeBuilder<AddressBook> builder)
            {
                builder.ToTable("AddressBook");
                builder.HasKey(s => s.Id).IsClustered(true);
                builder.HasData(
                new AddressBook
                { Id = 1, FullName = "Mina", JobId = 1, DepId = 1, MobilePhone = "01274556357", BirthDate =  new DateTime(2023, 01, 01), Age=31, Address="Madinaty", Email="minamoheb52@yahoo.com",Passowrd=null,Photo=null }
            
                );



            }
        }




    }

}
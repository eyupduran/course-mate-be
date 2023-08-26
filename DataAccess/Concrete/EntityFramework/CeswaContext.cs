using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Concrete.EntityFramework
{
    public class CeswaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=Course-Mate;Trusted_Connection=true");
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        public DbSet<CourseTeacher> CourseTeacher{ get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(p => p.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Email).HasColumnName("Email");
                a.HasIndex(p => p.Email, "UK_Users_Email").IsUnique();
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(p => p.Status).HasColumnName("Status");
                a.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");

            });

            modelBuilder.Entity<Student>(a =>
            {
                a.ToTable("Students");
                a.Property(p => p.StudentDetail).HasColumnName("StudentDetail");
                a.Property(p => p.GraduationStatus).HasColumnName("GraduationStatus");

            });
            modelBuilder.Entity<Teacher>(a =>
            {
                a.ToTable("Teachers");
                a.Property(p => p.Education).HasColumnName("Education");
                a.Property(p => p.Profession).HasColumnName("Profession");

            });
        }
    }
}

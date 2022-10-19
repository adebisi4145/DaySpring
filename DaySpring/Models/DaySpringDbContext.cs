using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Models
{
    public class DaySpringDbContext: DbContext
    {
        public DaySpringDbContext(DbContextOptions<DaySpringDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Preacher>(a =>
            {
                a.HasIndex(a => a.Name).IsUnique();
            });
            modelBuilder.Entity<Book>(a =>
            {
                a.HasIndex(a => a.ISBN).IsUnique();
            });
            modelBuilder.Entity<Member>(a =>
            {
                a.HasIndex(a => a.Email).IsUnique();
            });
            modelBuilder.Entity<User>(a =>
            {
                a.HasIndex(a => a.Email).IsUnique();
            });
            modelBuilder.Entity<Category>(a =>
            {
                a.HasIndex(a => a.Name).IsUnique();
            });

            modelBuilder.Entity<Role>().HasData(new Role { Id= 1, Name = "SuperAdmin" });
            modelBuilder.Entity<Role>().HasData(new Role { Id= 2, Name = "Member" });
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Email = "adeyemieyinjuoluwa@gmail.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("password") });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 1, RoleId = 1, UserId = 1 });
            modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 2, RoleId = 2, UserId = 1 });
            modelBuilder.Entity<Member>().HasData(new Member { UserId = 1, Id = 1, FirstName = "Adeyemi", LastName="Adebisi", Email = "adeyemieyinjuoluwa@gmail.com" });

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Sermon> Sermons { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Preacher> Preachers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<PaymentCategory> PaymentCategories{ get; set; }
    }
}

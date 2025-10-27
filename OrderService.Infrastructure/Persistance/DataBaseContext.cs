using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistance.EFConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance
{
    public class DataBaseContext : IdentityDbContext<AppUser>
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Feature> Features { get; set; }
       // public DbSet<AppUser> Features { get; set; }
        public DbSet<ProductFeature>  ProductFeatures { get; set; }
       public DbSet<Employee> Employees { get; set; }
        public DbSet<Product>  Products { get; set; }
        public DbSet<Size>  Sizes { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }

        public DbSet<State> States { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Actor>  Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<ActorMovie>  ActorMovie { get; set; }
        public DbSet<GenreMovie> GenreMovie { get; set; }
        public DbSet<MovieTheater> MovieTheater { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<SportStudent> SportStudent { get; set; }
        //public DbSet<AddressValueObject> AddressValueObject { get; set; }
        public DbSet<OrderTest> OrderTest { get; set; }
        public DbSet<Customer> Customer { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderTest>(b =>
            {
                b.ComplexProperty(x => x.ShippingAddress);
                b.ComplexProperty(c=>c.BillingAddress);
               

            }
            
              

           );
            modelBuilder.ApplyConfiguration(new OrderEfConfiguration());
            modelBuilder.ApplyConfiguration(new CustommerEfConfigurations());
            modelBuilder.ApplyConfiguration(new SportStudentEfConfigurations());
           // modelBuilder.ApplyConfiguration(new UserEfConfigurations());
            modelBuilder.HasDefaultSchema("ordering");
            modelBuilder.Entity<ActorMovie>().HasKey(p => new { p.MovieId, p.ActorId });
            modelBuilder.Entity<GenreMovie>().HasKey(p=>new {p.MovieId,p.GenreId});
            modelBuilder.Entity<MovieTheater>().HasKey(p => new { p.MovieId, p.TheaterId });
            modelBuilder.Entity<ProductSize>().HasKey(p=>new {p.ProductId,p.SizeId});
            modelBuilder.Entity<ProductFeature>().HasKey(p => new { p.ProductId, p.FeatureId });

            //modelBuilder.Entity<ProductSize>().ToTable()
            base.OnModelCreating(modelBuilder);
        }
       
    }
}

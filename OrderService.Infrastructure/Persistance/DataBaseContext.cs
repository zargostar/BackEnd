using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MongoDB.Bson;
using OrderService.Application.Contracts;
using OrderService.Domain.Common;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistance.EFConfigurations;
using OrderServise.Domain.Entities;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance
{
    public class DataBaseContext : IdentityDbContext<AppUser>
    {
        private readonly ICurrentUser user;
        public DataBaseContext(DbContextOptions options, ICurrentUser user) : base(options)
        {
            this.user = user;
        }
        public DbSet<Suplier> Supliers { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Category> Categories { get; set; }
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
            modelBuilder.ApplyConfiguration(new ProductEfConfiguration());
            modelBuilder.ApplyConfiguration(new ActorEfConfiguration());
            modelBuilder.ApplyConfiguration(new SuplierEfConfiguration());
            modelBuilder.HasDefaultSchema("ordering");
    
            
            modelBuilder.Entity<ActorMovie>().HasKey(p => new { p.MovieId, p.ActorId });
            modelBuilder.Entity<GenreMovie>().HasKey(p=>new {p.MovieId,p.GenreId});
            modelBuilder.Entity<MovieTheater>().HasKey(p => new { p.MovieId, p.TheaterId });
            modelBuilder.Entity<ProductSize>().HasKey(p=>new {p.ProductId,p.SizeId});
            modelBuilder.Entity<ProductFeature>().HasKey(p => new { p.ProductId, p.FeatureId });
            modelBuilder.Entity<Category>().Property(x=>x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.HasDbFunction(typeof(SqlServerJsonFunctions)
           .GetMethod(nameof(SqlServerJsonFunctions.JsonValue)))
           .HasName("JSON_VALUE")
           .IsBuiltIn();
            // modelBuilder.Entity<Category>().Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");



            base.OnModelCreating(modelBuilder);
        }


        public static class SqlServerJsonFunctions
            {
                [DbFunction("JSON_VALUE", IsBuiltIn = true)]
                public static string JsonValue(string json, [NotParameterized] string path)
                    => throw new NotSupportedException(); // only used in SQL translation
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           
          
            foreach (var entity in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entity.Entity.UpdatedAt = DateTime.UtcNow;
                        entity.Entity.DeletedBy = user.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }
}

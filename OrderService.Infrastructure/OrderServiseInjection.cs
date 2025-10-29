using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Contracts;
using OrderService.Infrastructure.MongoServises;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistance;
using OrderService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
    .Infrastructure
{
    public static  class OrderServiseInjection
    {
        public  static void  AddInfrastructurService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(c => c.UseSqlServer(configuration["sqlConnection"]));
            // 

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof( BaseRepositoryAsync<>),typeof( BaseRepositoryAsync<>));
            services.AddScoped<IMovirRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IStatesRepositoy,StatesRepository>();
            services.AddTransient(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddTransient<IOrderMongoService, OrderMongoService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IResumeRepository, ResumeRepository>();
            services .AddScoped<IActorRepository, ActorRepository>();


        }
    }
}

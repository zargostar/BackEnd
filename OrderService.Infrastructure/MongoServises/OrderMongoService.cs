using MongoDB.Driver;
using MongoDB.Driver.Linq;
using OrderService.Application.Contracts;
using OrderService.Domain.Entities;
using OrderService.Domain.Entities.Mongo;
using OrderService.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.MongoServises
{
    public class OrderMongoService : IOrderMongoService
    {
        private readonly IMongoRepository<OrderMongo> mongoDbContext;
        private readonly IMongoCollection<OrderMongo> mongoCollection;

        public OrderMongoService(IMongoRepository<OrderMongo> mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
            mongoCollection = mongoDbContext.GetCollection();
        }

        public async Task CreateOrder(OrderMongo order)
        {
           await mongoCollection.InsertOneAsync(order);
        }
    }
}

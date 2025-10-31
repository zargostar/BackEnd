﻿using Microsoft.EntityFrameworkCore;
using OrderService.Application.Contracts;
using OrderService.Application.Features.Movies.Dtos;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Repositories
{
    public class MovieRepository : BaseRepositoryAsync<Movie>, IMovirRepository
    {
        public MovieRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        //public async AsyncEnumerable<Movie> GetAsyncEnemorableMovie()

        //{
        //    return  _dbContext.Movies.AsAsyncEnumerable<Movie>();
        //    //var movie = await _dbContext.Movies.Include(p => p.GenreMovie).ThenInclude(o=>o.Genre).
        //    //      Include(p => p.ActorMovies)
        //    //      .Include(p => p.MovieTheater).ThenInclude(p=>p.Theater)
        //    //      .FirstOrDefaultAsync(x => x.Id == id);
        //    //return movie;
        //}

        IAsyncEnumerable<Movie> IMovirRepository.GetAsyncEnemorableMovie()
        {
            return _dbContext.Movies.AsAsyncEnumerable<Movie>();
        }
    }
}

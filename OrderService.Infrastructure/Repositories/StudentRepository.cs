using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OrderService.Application.Contracts;
using OrderService.Domain.Entities;

using OrderService.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace OrderService.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepositoryAsync<Student>, IStudentRepository
    {
        public StudentRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public async Task TestEf()
        {
            var stList =  new List<int> { 1, 23 };
          var sql= _dbContext.Products.Where(x => stList.Contains(x.Id)).ToQueryString();
          var sql0= _dbContext.Products.Where(x => stList.Contains(x.Id)).ToList();
          var sql00= _dbContext.Students.Where(x => x.SportStudents
          .Any(x=>stList.Contains(x.StudentId))).ToList();




        }

        private async Task ExplicitLoading()
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync();

            //with explicit loading we can load collections or refrences durring run  cobe where it is nrssesary

            var sports = _dbContext.Entry(student)
                .Collection(s => s.SportStudents)
                .Query().Where(x => x.SportLevel == SportLevel.Amator).ToList();
            var sportss = _dbContext.Entry(student)
                .Collection(s => s.SportStudents)
                .Query().ToList(); var cc = sportss.Count();
            var ccc = _dbContext.Entry(student).Collection(x => x.SportStudents).Query().Count();
            // var refrences=_dbContext.Entry(student).References(b=>book).load()
        }

        private void QuerySubquery()
        {
            var sports0 = _dbContext.Students.Where(x => _dbContext.SportStudent
            .Select(p => p.StudentId).Contains(x.Id)).ToList();
            var sss = _dbContext.Students.Where(x => x.SportStudents.
            Select(sp => sp.StudentId)
            .Contains(x.Id));
        }

        private static OrderTest ComplexType()
        {
            var address = new AddressValueObject("Esfahan", "Iran", "1111", "l1", "");

            var newTest = new OrderTest()
            {
                Contents = "ttt",
                BillingAddress = address with { Line1 = "s1", PostCode = "15000" },
                ShippingAddress = address with { PostCode = "180000" },
                //Id = 2,
                Customer = new Customer()
                {
                    Address = address with { PostCode = "55555" },
                    Name = "majid",

                }



            };
            return newTest;
        }

        private void ExcuteUpdateTest()
        {
            var updateExecut = _dbContext.Students.ExecuteUpdateAsync(st => st
            .SetProperty(x => x.Name, $"Test "));
            //update several field
            var updateExecut0 = _dbContext.Students.ExecuteUpdateAsync(st => st
            .SetProperty(x => x.Name, p => " Test 20" + p.Name)
            .SetProperty(x => x.BirthDate, p => p.BirthDate.AddYears(20))
            );
            //update with where conditions
            var updateExecut00 = _dbContext.Students
               .Where(x => x.SportStudents.Any(x => (int)x.SportLevel == 3))
               .ExecuteUpdateAsync(st => st.SetProperty(x => x.Name, p => " Test 20 alam any" + p.Name)
               .SetProperty(x => x.BirthDate, p => p.BirthDate.AddYears(20)));
        }

        private async Task LinqSamples()
        {
            var data = _dbContext.Students.Include(x => x.SportStudents).Where(x => x.SportStudents.Count() > 1)
                .Select(x => new { Name = x.Name, Count = x.SportStudents.Sum(x => (int)x.SportLevel) })
                .ToQueryString();
            //single query give us Left Join Explicity in query method
            var data2 = _dbContext.Students.Include(x => x.SportStudents).AsSingleQuery().ToQueryString();
            var data20 = _dbContext.Students.Include(x => x.SportStudents).AsSplitQuery().ToQueryString();
            var data22 = await _dbContext.Students.Include(x => x.SportStudents).AsSplitQuery().ToListAsync();
            //we can not have inner join with out linq query
            var data11 = (from s in _dbContext.Students
                          join sp in _dbContext.SportStudent
                        on s.Id equals sp.StudentId
                          select s).ToQueryString();

            //if we use having inner join group by is created
            var having = (from st in _dbContext.Students
                          join sp in _dbContext.SportStudent
                        on st.Id equals sp.StudentId
                          //where st.Id == 1
                          group sp by new { st.Name, st.Id } into g

                          where g.Count() > 2
                          select new { Id = g.Key.Id, Name = g.Key, count = g.Sum(x => x.SportId) }

                        ).AsSplitQuery().ToQueryString();
            var havingo = (from st in _dbContext.Students
                           join sp in _dbContext.SportStudent
                         on st.Id equals sp.StudentId
                           //where st.Id == 1
                           group sp by new { st.Name, st.Id } into g

                           where g.Count() > 2
                           select new { Id = g.Key.Id, Name = g.Key, count = g.Sum(x => x.SportId) }

                        ).AsSingleQuery().ToQueryString();

            //left join group by
            var Leftjoingroupby = (from st in _dbContext.Students
                                   join sp in _dbContext.SportStudent
                                   on st.Id equals sp.StudentId into def
                                   from newSp in def.DefaultIfEmpty()
                                   group newSp by new { st.Name, st.Id } into g
                                   //inner join
                                   select new { name = g.Key.Name, id = g.Key.Id, min = g.Min(x => x.StudentId), total = g.Count() }).ToQueryString();
            var Leftjoingroupby0 = (from st in _dbContext.Students
                                    join sp in _dbContext.SportStudent
                                    on st.Id equals sp.StudentId

                                    group sp by new { st.Name, st.Id } into g

                                    select new { name = g.Key.Name, id = g.Key.Id, total = g.Count() }).ToQueryString();
            ////////////////===================================>
            var lst = new List<int> { 1, 3 };
            var query = _dbContext.Students.Where(x => x.SportStudents.Any(x => x.SportId > 2)).ToQueryString();
            var query1 = _dbContext.Students.Where(x => x.SportStudents.Any()).ToQueryString();
            var query2 = _dbContext.Students.Where(x => lst.Contains(x.Id)).ToQueryString();
            var query3 = _dbContext.Students.Where(x => x.SportStudents.Any(x => lst.Contains(x.SportId))).ToQueryString();


            var res = _dbContext.Students.Where(st => st.SportStudents.All(x => x.SportId < 2)).ToList();
            var res00 = _dbContext.Students.Where(st => st.SportStudents.All(x => x.SportId < 2)).ToQueryString();
            var res000 = _dbContext.Students.Where(st => st.SportStudents.All(x => x.SportId < 2)).ToQueryString();
            var test = _dbContext.Students
                .SelectMany(x => x.SportStudents
            .Where(xx => (int)xx.SportLevel == 0)
            .Select(qq => new { id = x.Id, name = x.Name, level = qq.SportLevel })
            );

            var test000 = _dbContext.Students.SelectMany(x => x.SportStudents
            .Where(x => (int)x.SportLevel == 2)).ToQueryString();

            var letTest = (from s in _dbContext.Students
                           let type = s.Name.StartsWith("a") ? "ok" : "Not Ok"
                           select new { name = s.Name, Type = type }).ToList();
            var letTest0 = (from s in _dbContext.Students
                            let type = s.Name.StartsWith("a") ? "ok" : "Not Ok"
                            select new { name = s.Name, Type = type }).ToQueryString();


            var newLet = (from st in _dbContext.Students
                          let type = st.SportStudents.Any(x => (int)x.SportLevel == 2) ? "active" : "passive"
                          select new { Name = st.Name, ttt = type }
                        ).ToList();
            var newLet0 = (from st in _dbContext.Students
                           let type = st.SportStudents.Any(x => (int)x.SportLevel == 2) ? "active" : "passive"
                           select new { Name = st.Name, ttt = type }
                        ).ToQueryString();
        }
    }
}

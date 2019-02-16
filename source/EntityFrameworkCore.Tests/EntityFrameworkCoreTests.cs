using DotNetCore.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.EntityFrameworkCore.Tests
{
    [TestClass]
    public class EntityFrameworkCoreTests
    {
        public EntityFrameworkCoreTests()
        {
            var services = new ServiceCollection();

            services.AddDbContextPool<FakeContext>(options => options.UseInMemoryDatabase(nameof(FakeContext)));

            Context = services.BuildServiceProvider().GetService<FakeContext>();

            Context.Database.EnsureCreated();

            Repository = new FakeRepository(Context);

            SeedDatabase();
        }

        private FakeContext Context { get; }

        private IFakeRepository Repository { get; }

        [TestMethod]
        public void Add()
        {
            var entity = CreateEntity();
            Repository.Add(entity);
            Context.SaveChanges();
            Assert.IsNotNull(Repository.Select(entity.FakeEntityId));
        }

        [TestMethod]
        public void AddAsynchronous()
        {
            var entity = CreateEntity();
            Repository.AddAsync(entity);
            Context.SaveChanges();
            Assert.IsNotNull(Repository.Select(entity.FakeEntityId));
        }

        [TestMethod]
        public void AddRange()
        {
            var count = Repository.Count();
            Repository.AddRange(new List<FakeEntity> { CreateEntity() });
            Context.SaveChanges();
            Assert.IsTrue(Repository.Count() > count);
        }

        [TestMethod]
        public void AddRangeAsynchronous()
        {
            var count = Repository.Count();
            Repository.AddRangeAsync(new List<FakeEntity> { CreateEntity() });
            Context.SaveChanges();
            Assert.IsTrue(Repository.Count() > count);
        }

        [TestMethod]
        public void Any()
        {
            Assert.IsTrue(Repository.Any());
        }

        [TestMethod]
        public void AnyAsynchronous()
        {
            Assert.IsTrue(Repository.AnyAsync().Result);
        }

        [TestMethod]
        public void AnyWhere()
        {
            Assert.IsTrue(Repository.Any(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void AnyWhereAsynchronous()
        {
            Assert.IsTrue(Repository.AnyAsync(w => w.FakeEntityId == 1L).Result);
        }

        [TestMethod]
        public void Count()
        {
            Assert.IsTrue(Repository.Count() > 0);
        }

        [TestMethod]
        public void CountAsynchronous()
        {
            Assert.IsTrue(Repository.CountAsync().Result > 0);
        }

        [TestMethod]
        public void CountWhere()
        {
            Assert.IsTrue(Repository.Count(w => w.FakeEntityId == 1) == 1L);
        }

        [TestMethod]
        public void CountWhereAsynchronous()
        {
            Assert.IsTrue(Repository.CountAsync(w => w.FakeEntityId == 1L).Result == 1L);
        }

        [TestMethod]
        public void Delete()
        {
            Repository.Delete(70L);
            Context.SaveChanges();
        }

        [TestMethod]
        public void DeleteAsynchronous()
        {
            Repository.DeleteAsync(80L);
            Context.SaveChanges();
        }

        [TestMethod]
        public void DeleteWhere()
        {
            Repository.Delete(w => w.FakeEntityId == 90L);
            Context.SaveChanges();
        }

        [TestMethod]
        public void DeleteWhereAsynchronous()
        {
            Repository.DeleteAsync(w => w.FakeEntityId == 100L);
            Context.SaveChanges();
        }

        [TestMethod]
        public void FirstOrDefault()
        {
            Assert.IsNotNull(Repository.FirstOrDefault());
        }

        [TestMethod]
        public void FirstOrDefaultAsynchronous()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultAsync().Result);
        }

        [TestMethod]
        public void FirstOrDefaultInclude()
        {
            Assert.IsNotNull(Repository.FirstOrDefault(i => i.FakeEntityChild));
        }

        [TestMethod]
        public void FirstOrDefaultIncludeAsynchronous()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultAsync(i => i.FakeEntityChild));
        }

        [TestMethod]
        public void FirstOrDefaultResult()
        {
            Assert.IsNotNull(Repository.FirstOrDefault<FakeEntityModel>(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void FirstOrDefaultResultAsynchronous()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultAsync<FakeEntityModel>(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void FirstOrDefaultWhere()
        {
            Assert.IsNotNull(Repository.FirstOrDefault(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void FirstOrDefaultWhereAsynchronous()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultAsync(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void FirstOrDefaultWhereInclude()
        {
            Assert.IsNotNull(Repository.FirstOrDefault(w => w.FakeEntityId == 1L, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void FirstOrDefaultWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(Repository.FirstOrDefaultAsync(w => w.FakeEntityId == 1L, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void List()
        {
            Assert.IsNotNull(Repository.List());
        }

        [TestMethod]
        public void ListAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync());
        }

        [TestMethod]
        public void ListInclude()
        {
            Assert.IsNotNull(Repository.List(i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListIncludeAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync(i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListIncludeResult()
        {
            Assert.IsNotNull(Repository.List<FakeEntityModel>(i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListIncludeResultAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync<FakeEntityModel>(i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListPaged()
        {
            Assert.IsNotNull(Repository.List(new PagedListParameters()));
        }

        [TestMethod]
        public void ListPagedInclude()
        {
            Assert.IsNotNull(Repository.List(new PagedListParameters(), i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListPagedIncludeResult()
        {
            Assert.IsNotNull(Repository.List<FakeEntityModel>(new PagedListParameters(), i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListPagedResult()
        {
            Assert.IsNotNull(Repository.List<FakeEntityModel>(new PagedListParameters()));
        }

        [TestMethod]
        public void ListPagedWhere()
        {
            Assert.IsNotNull(Repository.List(new PagedListParameters(), w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void ListPagedWhereInclude()
        {
            Assert.IsNotNull(Repository.List(new PagedListParameters(), w => w.FakeEntityId == 1L, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListPagedWhereIncludeResult()
        {
            Assert.IsNotNull(Repository.List<FakeEntityModel>(new PagedListParameters(), w => w.FakeEntityId == 1L, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListPagedWhereResult()
        {
            Assert.IsNotNull(Repository.List<FakeEntityModel>(new PagedListParameters(), w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void ListResult()
        {
            Assert.IsNotNull(Repository.List<FakeEntityModel>());
        }

        [TestMethod]
        public void ListResultAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync<FakeEntityModel>());
        }

        [TestMethod]
        public void ListWhere()
        {
            Assert.IsNotNull(Repository.List(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void ListWhereAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void ListWhereInclude()
        {
            Assert.IsNotNull(Repository.List(w => w.FakeEntityId == 1L, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync(w => w.FakeEntityId == 1L, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListWhereIncludeResult()
        {
            Assert.IsNotNull(Repository.List<FakeEntityModel>(w => w.FakeEntityId == 1L, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListWhereIncludeResultAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync<FakeEntityModel>(w => w.FakeEntityId == 1L, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void ListWhereResult()
        {
            Assert.IsNotNull(Repository.List<FakeEntityModel>(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void ListWhereResultAsynchronous()
        {
            Assert.IsNotNull(Repository.ListAsync<FakeEntityModel>(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void Queryable()
        {
            Assert.IsNotNull(Repository.Queryable.OrderByDescending(o => o.FakeEntityId).FirstOrDefault());
        }

        [TestMethod]
        public void Select()
        {
            Assert.IsNotNull(Repository.Select(1L));
        }

        [TestMethod]
        public void SelectAsynchronous()
        {
            Assert.IsNotNull(Repository.SelectAsync(1L).Result);
        }

        [TestMethod]
        public void SelectResult()
        {
            var result = Repository.Select<FakeEntityModel>(1L);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Name);
        }

        [TestMethod]
        public void SelectResultAsynchronous()
        {
            var result = Repository.SelectAsync<FakeEntityModel>(1L).Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Name);
        }

        [TestMethod]
        public void SingleOrDefaultResult()
        {
            Assert.IsNotNull(Repository.SingleOrDefault<FakeEntityModel>(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void SingleOrDefaultResultAsynchronous()
        {
            Assert.IsNotNull(Repository.SingleOrDefaultAsync<FakeEntityModel>(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void SingleOrDefaultWhere()
        {
            Assert.IsNotNull(Repository.SingleOrDefault(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void SingleOrDefaultWhereAsynchronous()
        {
            Assert.IsNotNull(Repository.SingleOrDefaultAsync(w => w.FakeEntityId == 1L));
        }

        [TestMethod]
        public void SingleOrDefaultWhereInclude()
        {
            Assert.IsNotNull(Repository.SingleOrDefault(w => w.FakeEntityId == 1L, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void SingleOrDefaultWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(Repository.SingleOrDefaultAsync(w => w.FakeEntityId == 1L, i => i.FakeEntityChild));
        }

        [TestMethod]
        public void Update()
        {
            var entity = new FakeEntity
            {
                FakeEntityId = 1L,
                Name = Guid.NewGuid().ToString()
            };

            Repository.Update(entity, 1L);

            Context.SaveChanges();

            var entityDatabase = Repository.Select(1L);

            Assert.AreEqual(entity.Name, entityDatabase.Name);
        }

        [TestMethod]
        public void UpdateAsynchronous()
        {
            var entity = new FakeEntity
            {
                FakeEntityId = 1L,
                Name = Guid.NewGuid().ToString()
            };

            Repository.UpdateAsync(entity, 1L);

            Context.SaveChanges();

            var entityDatabase = Repository.Select(1L);

            Assert.AreEqual(entity.Name, entityDatabase.Name);
        }

        private static FakeEntity CreateEntity()
        {
            return new FakeEntity { Name = $"Name {Guid.NewGuid().ToString()}" };
        }

        private void SeedDatabase()
        {
            for (var i = 1L; i <= 100; i++)
            {
                Repository.Add(CreateEntity());
            }

            Context.SaveChanges();
        }
    }
}

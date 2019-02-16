using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.MongoDB.Tests
{
    [TestClass]
    public class MongoTests
    {
        public MongoTests()
        {
            const string connectionString = "mongodb://localhost/Database";
            var context = new FakeContext(connectionString);
            Repository = new FakeRepository(context);
        }

        public IFakeRepository Repository { get; }

        [TestMethod]
        public void Add()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsNotNull(Repository.Select(document.Id));
        }

        [TestMethod]
        public void AddAsynchronous()
        {
            var document = CreateDocument();
            Repository.AddAsync(document);
            Assert.IsNotNull(Repository.Select(document.Id));
        }

        [TestMethod]
        public void AddRange()
        {
            var count = Repository.Count();
            Repository.AddRange(new List<FakeDocument> { CreateDocument() });
            Assert.IsTrue(Repository.Count() > count);
        }

        [TestMethod]
        public void AddRangeAsynchronous()
        {
            var count = Repository.Count();
            Repository.AddRangeAsync(new List<FakeDocument> { CreateDocument() });
            Assert.IsTrue(Repository.Count() > count);
        }

        [TestMethod]
        public void Any()
        {
            Repository.Add(CreateDocument());
            Assert.IsTrue(Repository.Any());
        }

        [TestMethod]
        public void AnyAsynchronous()
        {
            Repository.Add(CreateDocument());
            Assert.IsTrue(Repository.AnyAsync().Result);
        }

        [TestMethod]
        public void AnyWhere()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsTrue(Repository.Any(x => x.Id == document.Id));
        }

        [TestMethod]
        public void AnyWhereAsynchronous()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsTrue(Repository.AnyAsync(x => x.Id == document.Id).Result);
        }

        [TestMethod]
        public void Count()
        {
            Repository.Add(CreateDocument());
            Assert.IsTrue(Repository.Count() > 0);
        }

        [TestMethod]
        public void CountAsynchronous()
        {
            Repository.Add(CreateDocument());
            Assert.IsTrue(Repository.CountAsync().Result > 0);
        }

        [TestMethod]
        public void CountWhere()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsTrue(Repository.Count(x => x.Id == document.Id) == 1);
        }

        [TestMethod]
        public void CountWhereAsynchronous()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsTrue(Repository.CountAsync(x => x.Id == document.Id).Result == 1);
        }

        [TestMethod]
        public void Delete()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsNotNull(Repository.Select(document.Id));
            Repository.Delete(document.Id);
            Assert.IsNull(Repository.Select(document.Id));
        }

        [TestMethod]
        public void DeleteAsynchronous()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsNotNull(Repository.Select(document.Id));
            Repository.DeleteAsync(document.Id);
            Assert.IsNull(Repository.Select(document.Id));
        }

        [TestMethod]
        public void DeleteWhere()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsNotNull(Repository.Select(document.Id));
            Repository.Delete(x => x.Id == document.Id);
            Assert.IsNull(Repository.Select(document.Id));
        }

        [TestMethod]
        public void DeleteWhereAsynchronous()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsNotNull(Repository.Select(document.Id));
            Repository.DeleteAsync(x => x.Id == document.Id);
            Assert.IsNull(Repository.Select(document.Id));
        }

        [TestMethod]
        public void FirstOrDefault()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsNotNull(Repository.FirstOrDefault(x => x.Id == document.Id));
        }

        [TestMethod]
        public void FirstOrDefaultAsynchronous()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsNotNull(Repository.FirstOrDefaultAsync(x => x.Id == document.Id).Result);
        }

        [TestMethod]
        public void List()
        {
            Repository.Add(CreateDocument());
            Assert.IsTrue(Repository.List().Any());
        }

        [TestMethod]
        public void ListAsynchronous()
        {
            Repository.Add(CreateDocument());
            Assert.IsTrue(Repository.ListAsync().Result.Any());
        }

        [TestMethod]
        public void ListWhere()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsTrue(Repository.List(x => x.Id == document.Id).Any());
        }

        [TestMethod]
        public void ListWhereAsynchronous()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsTrue(Repository.ListAsync(x => x.Id == document.Id).Result.Any());
        }

        [TestMethod]
        public void Select()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsNotNull(Repository.Select(document.Id));
        }

        [TestMethod]
        public void SelectAsynchronous()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsNotNull(Repository.SelectAsync(document.Id).Result);
        }

        [TestMethod]
        public void SingleOrDefault()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsNotNull(Repository.SingleOrDefault(x => x.Id == document.Id));
        }

        [TestMethod]
        public void SingleOrDefaultAsynchronous()
        {
            var document = CreateDocument();
            Repository.Add(document);
            Assert.IsNotNull(Repository.SingleOrDefaultAsync(x => x.Id == document.Id).Result);
        }

        [TestMethod]
        public void Update()
        {
            var document = CreateDocument();
            Repository.Add(document);
            var oldName = document.Name;
            document.Name = Guid.NewGuid().ToString();
            Repository.Update(document, document.Id);
            document = Repository.Select(document.Id);
            Assert.AreNotEqual(oldName, document.Name);
        }

        [TestMethod]
        public void UpdateAsynchronous()
        {
            var document = CreateDocument();
            Repository.Add(document);
            var oldName = document.Name;
            document.Name = Guid.NewGuid().ToString();
            Repository.UpdateAsync(document, document.Id);
            document = Repository.Select(document.Id);
            Assert.AreNotEqual(oldName, document.Name);
        }

        private static FakeDocument CreateDocument()
        {
            return new FakeDocument { Id = ObjectId.GenerateNewId(), Name = Guid.NewGuid().ToString() };
        }
    }
}

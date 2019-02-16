# DotNetCore.MongoDB

The package provides interfaces and classes for **MongoDB**.

## Context

### IMongoContext

```cs
public interface IMongoContext
{
    IMongoDatabase Database { get; }
}
```

### MongoContext

```cs
public abstract class MongoContext : IMongoContext
{
    protected MongoContext(string connectionString) { }

    public IMongoDatabase Database { get; }
}
```

## Document

### IDocument

```cs
public interface IDocument
{
    ObjectId Id { get; set; }
}
```

### Document

```cs
public abstract class Document : IDocument
{
    [BsonExtraElements]
    public BsonDocument ExtraElements { get; set; }

    public ObjectId Id { get; set; }
}
```

## MongoRepository

The **MongoRepository\<T\>** class implements **IRepository\<T\>** interface.

```cs
public abstract class MongoRepository<T> : IRepository<T> where T : class
{
    protected MongoRepository(IMongoContext context) { }

    public void Add(T item) { }

    public Task AddAsync(T item) { }

    public void AddRange(IEnumerable<T> items) { }

    public Task AddRangeAsync(IEnumerable<T> items) { }

    public bool Any() { }

    public bool Any(Expression<Func<T, bool>> where) { }

    public Task<bool> AnyAsync() { }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> where) { }

    public long Count() { }

    public long Count(Expression<Func<T, bool>> where) { }

    public Task<long> CountAsync() { }

    public Task<long> CountAsync(Expression<Func<T, bool>> where) { }

    public void Delete(object key) { }

    public void Delete(Expression<Func<T, bool>> where) { }

    public Task DeleteAsync(object key) { }

    public Task DeleteAsync(Expression<Func<T, bool>> where) { }

    public T FirstOrDefault(Expression<Func<T, bool>> where) { }

    public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where) { }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where) { }

    public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where) { }

    public IEnumerable<T> List() { }

    public IEnumerable<T> List(Expression<Func<T, bool>> where) { }

    public IEnumerable<TResult> List<TResult>() { }

    public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where) { }

    public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where) { }

    public async Task<IEnumerable<T>> ListAsync() { }

    public Task<IEnumerable<TResult>> ListAsync<TResult>() { }

    public Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where) { }

    public T Select(object key) { }

    public TResult Select<TResult>(object key) { }

    public Task<T> SelectAsync(object key) { }

    public Task<TResult> SelectAsync<TResult>(object key) { }

    public T SingleOrDefault(Expression<Func<T, bool>> where) { }

    public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where) { }

    public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where) { }

    public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where) { }

    public void Update(T item, object key) { }

    public Task UpdateAsync(T item, object key) { }

    private static FilterDefinition<T> FilterId(object key) { }
}
```

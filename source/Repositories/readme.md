# DotNetCore.Repositories

The package provides interfaces for **repositories**.

## IRepository

```cs
public interface IRepository<T> where T : class
{
    void Add(T item);

    Task AddAsync(T item);

    void AddRange(IEnumerable<T> items);

    Task AddRangeAsync(IEnumerable<T> items);

    bool Any();

    bool Any(Expression<Func<T, bool>> where);

    Task<bool> AnyAsync();

    Task<bool> AnyAsync(Expression<Func<T, bool>> where);

    long Count();

    long Count(Expression<Func<T, bool>> where);

    Task<long> CountAsync();

    Task<long> CountAsync(Expression<Func<T, bool>> where);

    void Delete(object key);

    void Delete(Expression<Func<T, bool>> where);

    Task DeleteAsync(object key);

    Task DeleteAsync(Expression<Func<T, bool>> where);

    T FirstOrDefault(Expression<Func<T, bool>> where);

    TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where);

    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where);

    Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where);

    IEnumerable<T> List();

    IEnumerable<T> List(Expression<Func<T, bool>> where);

    IEnumerable<TResult> List<TResult>();

    IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where);

    Task<IEnumerable<T>> ListAsync();

    Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where);

    Task<IEnumerable<TResult>> ListAsync<TResult>();

    Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where);

    T Select(object key);

    TResult Select<TResult>(object key);

    Task<T> SelectAsync(object key);

    Task<TResult> SelectAsync<TResult>(object key);

    T SingleOrDefault(Expression<Func<T, bool>> where);

    TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where);

    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where);

    Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where);

    void Update(T item, object key);

    Task UpdateAsync(T item, object key);
}
```

## IRelationalRepository

```cs
public interface IRelationalRepository<T> : IRepository<T> where T : class
{
    IQueryable<T> Queryable { get; }

    T FirstOrDefault(params Expression<Func<T, object>>[] include);

    T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

    Task<T> FirstOrDefaultAsync(params Expression<Func<T, object>>[] include);

    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

    IEnumerable<T> List(params Expression<Func<T, object>>[] include);

    IEnumerable<T> List(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    PagedList<T> List(PagedListParameters parameters, params Expression<Func<T, object>>[] include);

    PagedList<T> List(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    IEnumerable<TResult> List<TResult>(params Expression<Func<T, object>>[] include);

    IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    PagedList<TResult> List<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include);

    PagedList<TResult> List<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<PagedList<T>> ListAsync(PagedListParameters parameters, params Expression<Func<T, object>>[] include);

    Task<PagedList<T>> ListAsync(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include);

    Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<IEnumerable<T>> ListAsync(params Expression<Func<T, object>>[] include);

    Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<IEnumerable<TResult>> ListAsync<TResult>(params Expression<Func<T, object>>[] include);

    Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);

    Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);

    Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);
}
```

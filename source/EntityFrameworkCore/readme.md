# DotNetCore.EntityFrameworkCore

The package provides classes for **Entity Framework Core**.

## EntityFrameworkCoreExtensions

The **EntityFrameworkCoreExtensions** class provides **extension methods**.

```cs
public static class EntityFrameworkCoreExtensions
{
    public static void ApplyConfigurationsFromAssembly(this ModelBuilder modelBuilder) { }

    public static void DetectChangesLazyLoading(this DbContext context, bool enabled) { }

    public static IQueryable<T> Include<T>(this IQueryable<T> queryable, Expression<Func<T, object>>[] includes) where T : class { }
}
```

## EntityFrameworkCoreRepository\<T\>

The **EntityFrameworkCoreRepository\<T\>** class implements **IRelationalRepository\<T\>** interface.

```cs
public class EntityFrameworkCoreRepository<T> : IRelationalRepository<T> where T : class
{
    protected EntityFrameworkCoreRepository(DbContext context) { }

    public IQueryable<T> Queryable => Set.AsQueryable();

    private DbSet<T> Set => Context.Set<T>();

    private DbContext Context { get; }

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

    public T FirstOrDefault(params Expression<Func<T, object>>[] include) { }

    public T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where) { }

    public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where) { }

    public Task<T> FirstOrDefaultAsync(params Expression<Func<T, object>>[] include) { }

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where) { }

    public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }

    public IEnumerable<T> List() { }

    public IEnumerable<TResult> List<TResult>() { }

    public IEnumerable<T> List(Expression<Func<T, bool>> where) { }

    public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where) { }

    public IEnumerable<T> List(params Expression<Func<T, object>>[] include) { }

    public IEnumerable<TResult> List<TResult>(params Expression<Func<T, object>>[] include) { }

    public IEnumerable<T> List(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public PagedList<T> List(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public PagedList<TResult> List<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public PagedList<T> List(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public PagedList<TResult> List<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public async Task<IEnumerable<T>> ListAsync() { }

    public async Task<IEnumerable<TResult>> ListAsync<TResult>() { }

    public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where) { }

    public async Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where) { }

    public async Task<IEnumerable<T>> ListAsync(params Expression<Func<T, object>>[] include) { }

    public async Task<IEnumerable<TResult>> ListAsync<TResult>(params Expression<Func<T, object>>[] include) { }

    public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public async Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<T>> ListAsync(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<T>> ListAsync(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include) { }

    public Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public T Select(object key) { }

    public TResult Select<TResult>(object key) { }

    public Task<T> SelectAsync(object key) { }

    public Task<TResult> SelectAsync<TResult>(object key) { }

    public T SingleOrDefault(Expression<Func<T, bool>> where) { }

    public T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where) { }

    public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }

    public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where) { }

    public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include) { }

    public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where) { }

    public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select) { }

    public void Update(T item, object key) { }

    public Task UpdateAsync(T item, object key) { }
}
```

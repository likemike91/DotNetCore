using DotNetCore.Mapping;
using DotNetCore.Objects;
using DotNetCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.EntityFrameworkCore
{
    public class EntityFrameworkCoreRepository<T> : IRelationalRepository<T> where T : class
    {
        protected EntityFrameworkCoreRepository(DbContext context)
        {
            Context = context;
            Context.DetectChangesLazyLoading(false);
        }

        public IQueryable<T> Queryable => Set.AsQueryable();

        private DbSet<T> Set => Context.Set<T>();

        private DbContext Context { get; }

        public void Add(T item)
        {
            Set.Add(item);
        }

        public Task AddAsync(T item)
        {
            return Set.AddAsync(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            Set.AddRange(items);
        }

        public Task AddRangeAsync(IEnumerable<T> items)
        {
            return Set.AddRangeAsync(items);
        }

        public bool Any()
        {
            return Set.Any();
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return Set.Any(where);
        }

        public Task<bool> AnyAsync()
        {
            return Set.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return Set.AnyAsync(where);
        }

        public long Count()
        {
            return Set.LongCount();
        }

        public long Count(Expression<Func<T, bool>> where)
        {
            return Set.LongCount(where);
        }

        public Task<long> CountAsync()
        {
            return Set.LongCountAsync();
        }

        public Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            return Set.LongCountAsync(where);
        }

        public void Delete(object key)
        {
            Context.DetectChangesLazyLoading(true);

            var item = Select(key);

            if (item == null)
            {
                return;
            }

            Set.Remove(item);

            Context.DetectChangesLazyLoading(false);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            Context.DetectChangesLazyLoading(true);

            var items = Set.Where(where);

            if (!items.Any())
            {
                return;
            }

            Set.RemoveRange(items);

            Context.DetectChangesLazyLoading(false);
        }

        public Task DeleteAsync(object key)
        {
            Delete(key);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            Delete(where);

            return Task.CompletedTask;
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return Set.Where(where).FirstOrDefault();
        }

        public T FirstOrDefault(params Expression<Func<T, object>>[] include)
        {
            return Set.Include(include).FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Set.Where(where).Include(include).FirstOrDefault();
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return Set.Where(where).Project<T, TResult>().FirstOrDefault();
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return Set.Where(where).Select(select).FirstOrDefault();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return Set.Where(where).FirstOrDefaultAsync();
        }

        public Task<T> FirstOrDefaultAsync(params Expression<Func<T, object>>[] include)
        {
            return Set.Include(include).FirstOrDefaultAsync();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Set.Where(where).Include(include).FirstOrDefaultAsync();
        }

        public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return Set.Where(where).Project<T, TResult>().FirstOrDefaultAsync();
        }

        public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return Set.Where(where).Select(select).FirstOrDefaultAsync();
        }

        public IEnumerable<T> List()
        {
            return Set.ToList();
        }

        public IEnumerable<TResult> List<TResult>()
        {
            return Set.Project<T, TResult>().ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where)
        {
            return Set.Where(where).ToList();
        }

        public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where)
        {
            return Set.Where(where).Project<T, TResult>().ToList();
        }

        public IEnumerable<T> List(params Expression<Func<T, object>>[] include)
        {
            return Set.Include(include).ToList();
        }

        public IEnumerable<TResult> List<TResult>(params Expression<Func<T, object>>[] include)
        {
            return Set.Include(include).Project<T, TResult>().ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Set.Where(where).Include(include).ToList();
        }

        public IEnumerable<TResult> List<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Set.Where(where).Include(include).Project<T, TResult>().ToList();
        }

        public PagedList<T> List(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return new PagedList<T>(Set.Include(include), parameters);
        }

        public PagedList<TResult> List<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return new PagedList<TResult>(Set.Include(include).Project<T, TResult>(), parameters);
        }

        public PagedList<T> List(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return new PagedList<T>(Set.Where(where).Include(include), parameters);
        }

        public PagedList<TResult> List<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return new PagedList<TResult>(Set.Where(where).Include(include).Project<T, TResult>(), parameters);
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await Set.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> ListAsync<TResult>()
        {
            return await Set.Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where)
        {
            return await Set.Where(where).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return await Set.Where(where).Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(params Expression<Func<T, object>>[] include)
        {
            return await Set.Include(include).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> ListAsync<TResult>(params Expression<Func<T, object>>[] include)
        {
            return await Set.Include(include).Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return await Set.Where(where).Include(include).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> ListAsync<TResult>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return await Set.Where(where).Include(include).Project<T, TResult>().ToListAsync().ConfigureAwait(false);
        }

        public Task<PagedList<T>> ListAsync(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return Task.FromResult(List(parameters, include));
        }

        public Task<PagedList<T>> ListAsync(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Task.FromResult(List(parameters, where, include));
        }

        public Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters, params Expression<Func<T, object>>[] include)
        {
            return Task.FromResult(List<TResult>(parameters, include));
        }

        public Task<PagedList<TResult>> ListAsync<TResult>(PagedListParameters parameters, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Task.FromResult(List<TResult>(parameters, where, include));
        }

        public T Select(object key)
        {
            return Set.Find(key);
        }

        public TResult Select<TResult>(object key)
        {
            return Set.Find(key).Map<T, TResult>();
        }

        public Task<T> SelectAsync(object key)
        {
            return Set.FindAsync(key);
        }

        public Task<TResult> SelectAsync<TResult>(object key)
        {
            return Task.FromResult(Set.FindAsync(key).Result.Map<TResult>());
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return Set.Where(where).SingleOrDefault();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Set.Where(where).Include(include).SingleOrDefault();
        }

        public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where)
        {
            return Set.Where(where).Project<T, TResult>().SingleOrDefault();
        }

        public TResult SingleOrDefault<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return Set.Where(where).Select(select).SingleOrDefault();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return Set.Where(where).SingleOrDefaultAsync();
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            return Set.Where(where).Include(include).SingleOrDefaultAsync();
        }

        public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where)
        {
            return Set.Where(where).Project<T, TResult>().SingleOrDefaultAsync();
        }

        public Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select)
        {
            return Set.Where(where).Select(select).SingleOrDefaultAsync();
        }

        public void Update(T item, object key)
        {
            Context.DetectChangesLazyLoading(true);

            var entity = Select(key);

            if (entity == null)
            {
                return;
            }

            Context.Entry(entity).CurrentValues.SetValues(item);

            Context.DetectChangesLazyLoading(false);
        }

        public Task UpdateAsync(T item, object key)
        {
            Update(item, key);

            return Task.CompletedTask;
        }
    }
}

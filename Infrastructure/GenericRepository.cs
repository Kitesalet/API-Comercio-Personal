using Common.Interfaces;
using Common.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {

        _context = context;

        _dbSet = context.Set<T>();  

    }


    public async Task<int> AddAsync(T entity)
    {
       
        await _dbSet.AddAsync(entity);

        return entity.Id;


    }

    public void DeleteAsync(T entity)
    {
        
        if(_dbSet.Attach(entity).State == EntityState.Detached)
        {
            _context.Set<T>().Attach(entity);
        }

          _dbSet.Remove(entity);

      

    }

    public async Task<List<T>> GetAsync(int? skip, int? take, params Expression<Func<T, object>>[] includes)
    {

        IQueryable<T> query = _dbSet;

        if(skip != null)
        {
            query = query.Skip(skip.Value);
        }

        if(take != null)
        {
            query = query.Take(take.Value); 
        }

        foreach(var include in includes)
        {

            query = query.Include(include);

        }

        return await query.ToListAsync();

    
    }

    public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
    {

        IQueryable<T> query = _dbSet;

        query = query.Where(x => x.Id == id);

        foreach(var include in includes)
        {

            query = query.Include(include);
        }

        return await query.SingleOrDefaultAsync();
        


    }

    public async Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>>[] filters, int? skip, int? take, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach(var x in filters)
        {
            query = query.Where(x);
        }

        if (skip != null)
        {
            query = query.Skip(skip.Value);
        }

        if (take != null)
        {
            query = query.Take(take.Value);
        }

        foreach (var include in includes)
        {

            query = query.Include(include);

        }

        return await query.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void UpdateAsync(T entity)
    {

        _dbSet.Attach(entity);

        _context.Entry(entity).State = EntityState.Modified;


    }
}

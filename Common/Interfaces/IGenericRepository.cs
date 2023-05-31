using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{

    //Lista Filtrada

    public Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>>[] filter, int? skip, int? take, params Expression<Func<T, object>>[] includes);

    //Get Lista solo Includes

    public Task<List<T>> GetAsync(int? skip, int? take, params Expression<Func<T, object>>[] includes);

    //Get Id

    public Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);

    //Add

    public Task<int> AddAsync(T entity);

    //Update

    public void UpdateAsync(T entity);

    //Delete

    public void DeleteAsync(T entity);


    //SaveChanges

    public Task SaveChangesAsync();



}

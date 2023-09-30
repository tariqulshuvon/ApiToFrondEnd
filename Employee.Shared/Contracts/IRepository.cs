using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Shared.Contracts;

public interface IRepository<TEntiy,IModel,T> 
    where TEntiy : class,IEntity<T>,new()
    where IModel : class,IVM<T>,new()
    where T : IEquatable<T>
{
    /// <summary>
    /// Gets by identifier asynchronous
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task <IModel> GetByIdAsync(T id);
    /// <summary>
    /// Get All asynchronous
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<IModel>> GetAllAsync();
    /// <summary>
    /// Get All asynchronous
    /// </summary>
    /// <param name="includes"></param>
    /// <returns></returns>
    public Task<List<IModel>> GetAllAsync(params Expression<Func<TEntiy, object>>[] includes);
    /// <summary>
    /// Delete The asynchronous
    /// </summary>
    /// <param name="entiy"></param>
    /// <returns></returns>
    public Task DeleteAsync(TEntiy entiy);
    /// <summary>
    /// Delete The asynchronous
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<IModel> DeleteAsync(T id);

    /// <summary>
    /// Update the asynchronous
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entiy"></param>
    /// <returns></returns>
    public Task <IModel> UpdateAsync(T id,TEntiy entiy);
    /// <summary>
    /// Insert the asynchronous
    /// </summary>
    /// <param name="entiy"></param>
    /// <returns></returns>
    public Task<IModel> InsertAsync(TEntiy entiy);
}

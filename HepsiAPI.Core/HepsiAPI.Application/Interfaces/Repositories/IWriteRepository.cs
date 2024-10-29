using System;
using HepsiAPI.Domain.Common;

namespace HepsiAPI.Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class, IEntityBase, new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);
    Task<T> UpdateAsync(T entity);
    Task HardDeleteAsync(T entity); // bir veriyi komple silmek için
    // Task SoftDeleteAsync(T entity);  // veri silinmez görünmez kalır
}

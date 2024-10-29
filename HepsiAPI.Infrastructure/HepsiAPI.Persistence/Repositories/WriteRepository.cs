using System;
using HepsiAPI.Application.Interfaces.Repositories;
using HepsiAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HepsiAPI.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()

{
    private readonly DbContext _dbContext; //field

    public WriteRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private DbSet<T> Table { get => _dbContext.Set<T>(); }

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }
    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(() => Table.Update(entity));
        return entity;  // Task ten sonra T olmadığı için return e gerek yok

    }

    public async Task HardDeleteAsync(T entity)
    {
        await Task.Run(() => Table.Remove(entity));

    }

}

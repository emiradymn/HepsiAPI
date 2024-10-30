using System;
using HepsiAPI.Application.Interfaces.Repositories;
using HepsiAPI.Application.UnitOfWorks;
using HepsiAPI.Persistence.Context;
using HepsiAPI.Persistence.Repositories;

namespace HepsiAPI.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;

    }

    public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();  // eğer tek satırlık bir işlem ise parantezleri ve return kullanmadan bu şekilde  yazılabilir
    public int Save() => _dbContext.SaveChanges();
    public Task<int> SaveAsync() => _dbContext.SaveChangesAsync();
    IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);
    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);

}

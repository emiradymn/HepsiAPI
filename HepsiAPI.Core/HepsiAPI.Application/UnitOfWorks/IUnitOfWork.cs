using System;
using HepsiAPI.Application.Interfaces.Repositories;
using HepsiAPI.Domain.Common;

namespace HepsiAPI.Application.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
    IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
    Task<int> SaveAsync();
    int Save();


}

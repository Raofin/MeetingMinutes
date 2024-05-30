using Microsoft.EntityFrameworkCore.Storage;

namespace MeetingMinutes.Domain;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync();
    IDbContextTransaction BeginTransaction();
    void Rollback();
}

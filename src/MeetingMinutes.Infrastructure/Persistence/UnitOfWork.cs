using MeetingMinutes.Domain;
using Microsoft.EntityFrameworkCore.Storage;

namespace MeetingMinutes.Infrastructure.Persistence;

internal class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _context = dbContext;

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public IDbContextTransaction BeginTransaction()
    {
        return _context.Database.BeginTransaction();
    }

    public void Rollback()
    {
        _context.Database.RollbackTransaction();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

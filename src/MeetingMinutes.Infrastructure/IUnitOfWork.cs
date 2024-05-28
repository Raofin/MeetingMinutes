namespace MeetingMinutes.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync();
}
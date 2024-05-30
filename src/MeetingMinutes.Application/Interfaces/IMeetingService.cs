using MeetingMinutes.Application.ViewModels;

namespace MeetingMinutes.Application.Interfaces;

public interface IMeetingService
{
    Task SaveMeetingAsync(MeetingViewModel model);
}
using MeetingMinutes.Domain.Entities;

namespace MeetingMinutes.Domain.Repositories;

public interface IMeetingRepository
{
    void AddMeetingDetails(MeetingMinutesDetails meetingMinutesDetails);
    void AddMeetingMaster(MeetingMinutesMaster meetingMinutesMaster);
    Task<long> SaveMeetingMinutesMasterAsync(MeetingMinutesMaster entity);
    Task SaveMeetingMinutesDetailAsync(MeetingMinutesDetails entity);
}
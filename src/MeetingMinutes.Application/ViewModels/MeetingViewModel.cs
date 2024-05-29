using MeetingMinutes.Application.Common;

namespace MeetingMinutes.Application.ViewModels;

public record MeetingViewModel(
    long? MeetingMinutesId,
    string Place,
    string ClientSide,
    string HostSide,
    string Agenda,
    string Discussion,
    string Decision,
    DateTime? Datetime,
    long? CustomerId,
    CustomerType CustomerType
);

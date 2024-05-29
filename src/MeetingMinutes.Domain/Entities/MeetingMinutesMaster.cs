namespace MeetingMinutes.Domain.Entities;

public class MeetingMinutesMaster
{
    public long MeetingMinutesId { get; set; }
    public string Place { get; set; } = null!;
    public string ClientSide { get; set; } = null!;
    public string HostSide { get; set; } = null!;
    public string Agenda { get; set; } = null!;
    public string Discussion { get; set; } = null!;
    public string Decision { get; set; } = null!;
    public DateTime? Datetime { get; set; }

    public long? CorporateCustomerId { get; set; }
    public long? IndividualCustomerId { get; set; }
    public long? MeetingDetailsId { get; set; }

    public CorporateCustomer? CorporateCustomer { get; set; }
    public IndividualCustomer? IndividualCustomer { get; set; }
    public MeetingMinutesDetails? MeetingDetails { get; set; }
}
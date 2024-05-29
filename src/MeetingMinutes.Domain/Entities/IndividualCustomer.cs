namespace MeetingMinutes.Domain.Entities;

public class IndividualCustomer
{
    public long CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;

    public ICollection<MeetingMinutesMaster> MeetingMinutesMasterTbls { get; set; } = new List<MeetingMinutesMaster>();
}

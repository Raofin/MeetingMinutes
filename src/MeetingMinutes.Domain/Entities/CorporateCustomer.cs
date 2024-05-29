namespace MeetingMinutes.Domain.Entities;

public class CorporateCustomer
{
    public long CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;

    public virtual ICollection<MeetingMinutesMaster> MeetingMinutesMasterTbls { get; set; } = new List<MeetingMinutesMaster>();
}

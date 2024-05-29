namespace MeetingMinutes.Domain.Entities;

public class MeetingMinutesDetails
{
    public long DetailsId { get; set; }
    public int? Quantity { get; set; }
    public string? Unit { get; set; }

    public long? ProductServiceId { get; set; }
    public ProductsService ProductService { get; set; } = null!;

    public ICollection<MeetingMinutesMaster> MeetingMinutesMasterTbls { get; set; } = new List<MeetingMinutesMaster>();
}

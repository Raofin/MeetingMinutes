namespace MeetingMinutes.Domain.Entities;

public class ProductsService
{
    public long ProductServiceId { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;

    public ICollection<MeetingMinutesDetails> MeetingMinutesDetailsTbls { get; set; } = new List<MeetingMinutesDetails>();
}
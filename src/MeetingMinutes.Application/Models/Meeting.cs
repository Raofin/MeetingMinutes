using MeetingMinutes.Application.Common;

namespace MeetingMinutes.Application.ViewModels;

/*public record MeetingViewModel(
    List<CustomerDDL> CustomerDDL,
    List<ProductServiceDDL> ProductServiceDDL,
    CustomerType? CustomerType = null,
    long? CustomerId = null,
    DateTime? Datetime = null,
    string? Place = null,
    string? ClientSide = null,
    string? HostSide = null,
    string? Agenda = null,
    string? Discussion = null,
    string? Decision = null,
    List<ProductServiceViewModel>? ProductServices = null
);*/


public class MeetingViewModel
{
    public List<CustomerDDL> CustomerDDL { get; set; } = [];
    public List<ProductServiceDDL> ProductServiceDDL { get; set; } = [];
    public CustomerType CustomerType { get; set; }
    public long CustomerId { get; set; }
    public DateTime? Datetime { get; set; }
    public string Place { get; set; } = null!;
    public string ClientSide { get; set; } = null!;
    public string HostSide { get; set; } = null!;
    public string Agenda { get; set; } = null!;
    public string Discussion { get; set; } = null!;
    public string Decision { get; set; } = null!;
    public List<ProductServiceViewModel>? ProductServices { get; set; }
}

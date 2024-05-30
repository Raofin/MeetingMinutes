namespace MeetingMinutes.Application.ViewModels;

public record ProductServiceDDL(
    long? ProductServiceId,
    string Name,
    string Type
);

public record ProductServiceViewModel(
    long? ProductServiceId,
    int Quantity,
    string Unit
);
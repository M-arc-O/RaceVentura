namespace RaceVenturaWebApp.Infrastructure.Entities;
public class Race
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
}

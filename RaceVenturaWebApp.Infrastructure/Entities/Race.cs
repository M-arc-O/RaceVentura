namespace RaceVenturaWebApp.Infrastructure.Entities;
public class Race
{
    public Guid Id { get; internal set; }
    public string Name { get; internal set; }

    private Race() { }

    public Race(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}

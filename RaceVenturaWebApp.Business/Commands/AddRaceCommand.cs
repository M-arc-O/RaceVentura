using RaceVenturaWebApp.Business.CQRS;

namespace RaceVenturaWebApp.Business.Commands;
public class AddRaceCommand : ICommand
{
	public Guid UserId { get; set; }
	public string Name { get; }

	public AddRaceCommand(Guid userId, string name)
	{
		UserId = userId;
		Name = name;
	}
}

using RaceVenturaWebApp.Business.CQRS;

namespace RaceVenturaWebApp.Business.Queries;
public class GetAllRacesQuery : IQuery
{
    public Guid UserId { get; }

	public GetAllRacesQuery(Guid userId)
	{
		UserId = userId;
	}
}

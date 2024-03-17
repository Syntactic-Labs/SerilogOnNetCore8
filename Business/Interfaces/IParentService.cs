using Entities.Responses;

namespace Business.Interfaces;

public interface IParentService
{
	public Task<Parent?> GetParent(string id);
}

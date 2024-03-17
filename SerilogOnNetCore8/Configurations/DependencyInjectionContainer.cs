using Business.Interfaces;
using Business.Services;

namespace SerilogOnNetCore8.Configurations;

public static class DependencyInjectionContainer
{
	public static void InjectDependencies(this IServiceCollection serviceContainer)
	{
		serviceContainer.AddSingleton<IParentService, ParentService>();
	}
}

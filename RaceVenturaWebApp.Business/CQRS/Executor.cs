using AutoMapper;
using RaceVenturaWebApp.Infrastructure;
using RaceVenturaWebApp.Infrastructure.Entities;
using RaceVenturaWebApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace RaceVenturaWebApp.Business.CQRS;
public class Executor : IExecutor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;

	public Executor(IServiceProvider serviceProvider, IUnitOfWork unitOfWork, IGenericRepository<User> userRepository, IMapper mapper)
	{
        _serviceProvider = serviceProvider;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
	}

	public async Task<TResult> Execute<TExecutable, TResult>(TExecutable executable) where TExecutable : IExecutable
    {
        var handler = _serviceProvider.GetService<IHandler<TExecutable, TResult>>();
        if (handler == null)
        {
            throw new Exception($"No handler registered for executable '{typeof(TExecutable)}'");
        }

        var result = await handler.ExecuteAsync(executable);

        if (executable is ICommand)
        {
            await _unitOfWork.CommitAsync();
        }

        return result;
    }
}

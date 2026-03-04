using MediatR;

namespace ClassLibrary1.CQRS;

public interface ICommand:ICommand<Unit>{}
public interface ICommand<out TResponse >:IRequest<TResponse>
{
    
}
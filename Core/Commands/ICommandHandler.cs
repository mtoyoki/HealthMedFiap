namespace Core.Commands
{
    public interface ICommandHandler<in T>
    {
        CommandResult Handle(T command);
    }
}
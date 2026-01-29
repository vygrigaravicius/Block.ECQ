
namespace Blocks.ECQ.Commands
{
    public interface ICommand<out TResult>:
        ICommand
    {

    }

    /// <summary>
    /// Marker Interface.
    /// </summary>
    public interface ICommand
    {

    }
}

using System;
namespace Invoicer.Common.Handlers
{
    public interface ICommandHandler { }
    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        void Handle(T command);
    }
}

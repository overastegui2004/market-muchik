using market.muchik.domain.bus;
using market.muchik.domain.commands;
using market.muchik.domain.events;

namespace market.muchik.domain.bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;
        void Publish<T>(T @event) where T : Event;
        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}

using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Services
{
    public interface IEventService
    {
        // TODO: REMOVE THIS ONCE DONE TESTING
        public ObjectResult GetEvents();
        public ObjectResult GetEvent(int eventId);
        public ObjectResult UpdateEvent(int eventId, Event eventToUpdateTo);
        public ObjectResult RemoveEvent(int eventId);
        public ObjectResult CreateEvent(Event eventToCreate);
    }
}

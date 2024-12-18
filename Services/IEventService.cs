using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Services
{
    public interface IEventService
    {
        public ContentResult GetEvent(int eventId);
        public ContentResult UpdateEvent(int eventId, Event eventToUpdateTo);
        public ContentResult RemoveEvent(int eventId);
        public ContentResult CreateEvent(Event eventToCreate);
    }
}

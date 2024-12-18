using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace backend.Services
{
    public class EventService : IEventService
    {
        private readonly ILogger<EventService> _logger;

        public EventService(ILogger<EventService> logger)
        {
            _logger = logger;
        }

        public ContentResult CreateEvent(Event eventToCreate)
        {
            throw new NotImplementedException();
        }

        public ContentResult GetEvent(int eventId)
        {
            return new ContentResult
            {
                Content = "Success but in the service!"
            };
        }

        public ContentResult RemoveEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public ContentResult UpdateEvent(int eventId, Event eventToUpdateTo)
        {
            throw new NotImplementedException();
        }
    }
}

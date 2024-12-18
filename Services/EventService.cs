using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace backend.Services
{
    public class EventService : IEventService
    {
        private readonly ILogger<EventService> _logger;
        private Dictionary<int, Event> mockedEventData = new Dictionary<int, Event>()
        {
            { 1, new Event {
                    id = 1,
                    title = "Test Event 1",
                    duration = 180,
                    people =
                    [
                        new User { id = 1, firstName = "Caleb", lastName = "Ninal", nickName = "Caleb" },
                        new User { id = 2, firstName = "Karine", lastName = "Narvaez", nickName = "Banshee" },
                        new User { id = 3, firstName = "Tokyo", lastName = "Man", nickName = "Tokis" },
                        new User { id = 4, firstName = "Mandos", lastName = "Man", nickName = "The Mandos Man" },
                    ],
                    timeStart = new DateTime()
                }
            },
            { 2, new Event {
                    id = 2,
                    title = "Test Event 2",
                    duration = 90,
                    people =
                    [
                        new User { id = 1, firstName = "Caleb", lastName = "Ninal", nickName = "Caleb" },
                        new User { id = 3, firstName = "Tokyo", lastName = "Man", nickName = "Tokis" },
                        new User { id = 4, firstName = "Mandos", lastName = "Man", nickName = "The Mandos Man" }
                    ],
                    timeStart = new DateTime()
                }
            }
        };


        public EventService(ILogger<EventService> logger)
        {
            _logger = logger;
        }

        public ObjectResult GetEvents()
        {
            return new OkObjectResult(mockedEventData);
        }

        public ObjectResult CreateEvent(Event eventToCreate)
        {
            throw new NotImplementedException();
        }

        public ObjectResult GetEvent(int eventId)
        {
            Event? eventToFind;
            mockedEventData.TryGetValue(eventId, out eventToFind);
            ObjectResult result = new ObjectResult(new Event());

            if (eventToFind == null)
            {
                result.StatusCode = (int) HttpStatusCode.NotFound;
            } else
            {
                result.StatusCode = (int)HttpStatusCode.OK;
            }

            return result;
        }

        public ObjectResult RemoveEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public ObjectResult UpdateEvent(int eventId, Event eventToUpdateTo)
        {
            throw new NotImplementedException();
        }
    }
}

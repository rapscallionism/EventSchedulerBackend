using backend.Models;
using backend.Utils;
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
            // TODO: write validations on the event that it is a valid event to create in the first palce
            bool isValidEvent = validateEvent(eventToCreate);

            if (!isValidEvent)
            {
                return new BadRequestObjectResult("Event is not valid");
            }

            // TODO: database connection and committing; read valid entry and push to db
            return new OkObjectResult(eventToCreate);
        }

        public bool validateEvent(Event eventToValidate)
        {
            UsefulUtils.assertCondition(eventToValidate != null);

            // TODO: implement data validation
            return true;
        }

        public ObjectResult GetEvent(int eventId)
        {
            Event? eventToFind;
            mockedEventData.TryGetValue(eventId, out eventToFind);

            if (eventToFind == null)
            {
                var result = new NotFoundObjectResult("Object with id of " + eventId + " not found.");
                return result;
            } else
            {
                var result = new OkObjectResult(eventToFind);
                return result;
            }
        }

        public ObjectResult RemoveEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public ObjectResult UpdateEvent(int eventId, Event eventToUpdateTo)
        {
            // Grab the existing event
            Event? existingEvent = null;
            mockedEventData.TryGetValue(eventId, out existingEvent);

            if (existingEvent == null)
            {
                return new NotFoundObjectResult("Event with id of " + eventId + " not found.");
            }

            // Update the details to the entire event
            // TODO: would this be better implemented as a patch, find out the diff only if there's a diff?
            mockedEventData[eventId] = eventToUpdateTo;

            // Return the updated event
            return new OkObjectResult(eventToUpdateTo);
        }
    }
}

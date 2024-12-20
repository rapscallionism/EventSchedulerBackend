using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Services;

namespace backend.Controllers;

[Route("[controller]")]
public class EventsController : Controller
{
    private readonly ILogger<EventsController> _logger;
    private readonly IEventService _eventService;

    public EventsController(ILogger<EventsController> logger,
        IEventService eventService)
    {
        _logger = logger;
        _eventService = eventService;
    }

    [HttpGet]
    public ObjectResult GetEvents()
    {
        return _eventService.GetEvents();
    }

    [HttpGet("{eventId:int}")]
    public ObjectResult GetEvent(int eventId) {
        return _eventService.GetEvent(eventId);
    }

    [HttpPost]
    public ObjectResult CreateEvent([FromBody] Event eventToCreate) {
        return _eventService.CreateEvent(eventToCreate);
    }

    [HttpPut("{eventId:int}")]
    public ObjectResult UpdateEvent(int eventId, [FromBody] Event eventToUpdateTo)
    {
        return _eventService.UpdateEvent(eventId, eventToUpdateTo);
    }

    [HttpDelete("{eventId:int}")]
    public ObjectResult RemoveEvent(int eventId)
    {
        return _eventService.RemoveEvent(eventId);
    }

}

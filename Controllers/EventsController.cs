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

    [HttpGet("{eventId}")]
    public ObjectResult GetEvent(int eventId) {
        return _eventService.GetEvent(eventId);
    }

    public ObjectResult CreateEvent(Event eventToCreate) {
        return _eventService.CreateEvent(eventToCreate);
    }

    public ObjectResult UpdateEvent(int eventId, Event eventToUpdateTo)
    {
        return _eventService.UpdateEvent(eventId, eventToUpdateTo);
    }

    public ObjectResult RemoveEvent(int eventId)
    {
        return _eventService.RemoveEvent(eventId);
    }

}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Services;

namespace backend.Controllers;

public class EventController : Controller
{
    private readonly ILogger<EventController> _logger;
    private readonly IEventService _eventService;

    public EventController(ILogger<EventController> logger, 
        IEventService eventService)
    {
        _logger = logger;
        _eventService = eventService;
    }

    public IActionResult GetEvent(int eventId) {
        return _eventService.GetEvent(eventId);
    }

}

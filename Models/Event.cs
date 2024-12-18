

namespace Event_Scheduler.Models;

public class Event
{
    private int id;
    private string title;
    private int duration;
    private User[] people;
    private DateTime timeStart;
}

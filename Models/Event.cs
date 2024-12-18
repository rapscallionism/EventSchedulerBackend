

namespace backend.Models;

public class Event
{
    public int id;
    public string title;
    public int duration;
    public User[] people;
    public DateTime timeStart;
}

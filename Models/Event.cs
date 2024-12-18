

namespace backend.Models;

public class Event
{
    public int id { get; set; }
    public string title { get; set;}
    public int duration { get; set;}
    public User[] people { get; set;}
    public DateTime timeStart { get; set;}
}

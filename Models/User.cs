
namespace backend.Models;

// TODO: figure out the representation of data to suit the bi-directionality of User to event
public class User
{
    public int id { get; set; }
    public string firstName {get; set;}
    public string lastName {get; set;}
    public string nickName {get; set;}
}

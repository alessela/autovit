namespace webAPI.Models;

public class Message : Base
{
    public int SenderId { get; set; }
    public int ReceiverId { get; set;  }
    public string? Content { get; set; }
    public DateTime Date { get; set; }
}
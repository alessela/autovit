

namespace webAPI.Models;

public class CarEvent : Base
{
    public int CarId { get; set; }
    public string? Name { get; set; }
    public DateTime Date { get; set; }
}
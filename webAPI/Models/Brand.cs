using System.ComponentModel.DataAnnotations;

namespace webAPI.Models;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
}
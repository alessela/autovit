namespace webAPI.Models;

public class Car : Base
{
    public string? Name { get; set; }
    public int ModelId { get; set; }
    public int BodyStyleId { get; set; }
    public int Price { get; set; }
    public int Year { get; set; }
    public int Mileage { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }
    public int Engine { get; set; }
    public int Power { get; set; }
    public int ColorId { get; set; }
    public bool Rhd { get; set; }
    public bool New { get; set; }
    public int SellerId { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
}
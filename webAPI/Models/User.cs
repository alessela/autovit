namespace webAPI.Models;

public class User : Base
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
    public bool IsAdmin { get; set; }

    public User(int id, string firstName, string lastName, string email, string password, string phoneNumber, 
        string address, int cityId, bool isAdmin)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Address = address;
        CityId = cityId;
        IsAdmin = isAdmin;
    }
}
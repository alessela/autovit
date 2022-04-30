namespace webAPI.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public bool IsAdmin { get; }

    public User(int id, string firstName, string lastName, string email, string password, string phoneNumber, string address, bool isAdmin)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Address = address;
        IsAdmin = isAdmin;
    }
}
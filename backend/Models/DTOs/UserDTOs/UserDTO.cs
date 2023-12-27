namespace backend.Models.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}
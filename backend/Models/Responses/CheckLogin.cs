namespace backend.Models.Responses;

public class CheckLogin
{
    public bool IsLoggedIn { get; set; }
    public string? UserId { get; set; }
}
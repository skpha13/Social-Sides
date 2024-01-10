namespace backend.Helpers;

public class EmailNotFoundException : Exception
{
    public EmailNotFoundException() {}
    public EmailNotFoundException(string message): base(message) {}
    public EmailNotFoundException(string message, Exception inner): base(message, inner) {}
}
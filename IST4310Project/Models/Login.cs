namespace IST4310Project.Models
{
    public class Login
    {
        public string UserName { get; set; } = string.Empty;    
        public string Password { get; set; } = string.Empty;
        public string AuthenticationError { get; set; } = string.Empty;
    }
}

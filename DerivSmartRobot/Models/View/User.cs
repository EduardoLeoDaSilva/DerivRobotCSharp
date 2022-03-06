namespace DerivSmartRobot.Models.View
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Robots { get; set; }
        public bool Active { get; set; }

        public string TokensOAuth { get; set; }

        public DateTime? TokenDateDeadLine { get; set; }

        public string JwtToken { get; set; }

    }

    public enum AccountType
    {
        Demo,
        Real
    }
}

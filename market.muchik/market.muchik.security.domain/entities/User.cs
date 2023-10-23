namespace market.muchik.security.domain.entities
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}

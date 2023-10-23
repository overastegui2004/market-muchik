namespace market.muchik.infra.crosscutting.Jwt
{
    public interface IJwtManager
    {
        string GenerateToken(string userId, string username);
    }
}

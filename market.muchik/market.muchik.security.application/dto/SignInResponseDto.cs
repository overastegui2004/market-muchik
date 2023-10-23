namespace market.muchik.security.application.dto
{
    public class SignInResponseDto : UserDto
    {
        public string Token { get; set; } = null!;
    }
}

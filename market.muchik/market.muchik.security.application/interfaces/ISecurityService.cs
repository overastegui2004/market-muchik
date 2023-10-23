using market.muchik.security.application.dto;

namespace market.muchik.security.application.interfaces
{
    public interface ISecurityService
    {
        void SignUp(CreateUserDto userDto);
        SignInResponseDto SignIn(SignInRequestDto signInRequestDto);
        ICollection<UserDto> GetAllUsers();
    }
}

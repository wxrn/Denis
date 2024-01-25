namespace BackendApi.Contracts.User
{
    public class CreateUserRequest
    {
        public string UsersName { get; set; } = null!;
        public int Age { get; set; } 
        public string Passwords { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}

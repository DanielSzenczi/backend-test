using LAIT.Common;


namespace LAIT.Service
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserAsync(string id);

        public Task<List<UserDTO>> GetAllUsersAsync(int list_limit);

        public Task<string> CreateUserAsync(UserDTO user);

        public Task<string> DeleteUserAsync(string id);
    }
}

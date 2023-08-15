using LAIT.Common;


namespace LAIT.Repository
{
    public interface IUserRepository
    {
        public Task<UserDTO> GetUserAsync(string id);

        public Task<List<UserDTO>> GetAllUsersAsync(int list_limit);

        public Task<string> CreateUserAsync(UserDTO user);

        public Task<string> DeleteUserAsync(string id);
    }
}

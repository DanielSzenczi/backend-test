using LAIT.Common;
using LAIT.Repository;


namespace LAIT.Service
{
    public class UserService : IUserService
    {

        private static readonly UserRepository UserRepo = new ();



        public async Task<UserDTO> GetUserAsync(string id)
        {
           
            try
            {
                return await UserRepo.GetUserAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Method terminated with exception: {ex}");
                return null;
            }
            

        }

        public async Task<List<UserDTO>> GetAllUsersAsync(int list_limit)
        {
            try
            {
                return await UserRepo.GetAllUsersAsync(list_limit);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Method terminated with exception: {ex}");
                return null;
            }
        }



        public async Task<string> CreateUserAsync(UserDTO user)
        {

            try
            {
                return await UserRepo.CreateUserAsync(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Method terminated with exception: {ex}");
                return null;
            }
        }



        public async Task<string> DeleteUserAsync(string id)
        {
            try
            {
                return await UserRepo.DeleteUserAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Method terminated with exception: {ex}");
                return null;
            }
        }
    }
}

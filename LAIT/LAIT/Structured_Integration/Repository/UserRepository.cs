using LAIT.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace LAIT.Repository
{
    public class UserRepository : IUserRepository
    {

        private static string BASE_URL = "https://reqres.in/api";
        private readonly RestClient Client;

        public UserRepository()
        {
            var option = new RestClientOptions(BASE_URL)
            {
                ThrowOnAnyError = true
            };
            Client = new RestClient(option);
        }

        public async Task<UserDTO> GetUserAsync(string id)
        {
            try
            {

                var response = await Client.ExecuteAsync(new RestRequest($"/users/{id}"), Method.Get);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                else
                {
                    var parsedObject = JObject.Parse(response.Content);
                    var data = parsedObject["data"].ToString();
                    return JsonConvert.DeserializeObject<UserDTO>(data);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<UserDTO>> GetAllUsersAsync(int list_limit)
        {
            try
            {

                var response = await Client.ExecuteAsync(new RestRequest($"/users?per_page={list_limit}"), Method.Get);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                else
                {
                    JObject parsedObject = JObject.Parse(response.Content);
                    var data = parsedObject["data"].ToString();
                    return JsonConvert.DeserializeObject<List<UserDTO>>(data);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<string> CreateUserAsync(UserDTO user)
        {

            try
            {
                var response = await Client.ExecuteAsync(new RestRequest("api/users").AddJsonBody(user), Method.Post);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return response.StatusCode.ToString();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<string> DeleteUserAsync(string id)
        {
            try
            {
                var response = await Client.ExecuteAsync(new RestRequest($"api/users/{id}", Method.Delete));

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return response.StatusCode.ToString();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}



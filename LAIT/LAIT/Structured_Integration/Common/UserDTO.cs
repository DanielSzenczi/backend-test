using Newtonsoft.Json;


//User Data Transfer Class/POCO
namespace LAIT.Common
{
    public class UserDTO
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("avatar")]
        public string? Avatar { get; set; } 

    }
}

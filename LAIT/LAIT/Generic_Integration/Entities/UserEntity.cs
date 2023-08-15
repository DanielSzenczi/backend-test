using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAIT.Generic_Integration.Entities
{
    public class UserEntity : Repository<UserEntity>
    {



        public UserEntity(string path) : base(path)
        {

        }


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

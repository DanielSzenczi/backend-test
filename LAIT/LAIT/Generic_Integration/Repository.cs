using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace LAIT.Generic_Integration
{
    //A generic Repository class that implements the IRepository CRUD interface
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        private static string BASE_URL = "https://reqres.in/api";
        private readonly RestClient Client;
        protected string Path;

        public Repository(string path)
        {
            var option = new RestClientOptions(BASE_URL)
            {
                ThrowOnAnyError = true
            };
            this.Path = path;
            Client = new RestClient(option);
        }


        /// <summary>
        /// Fetches a specific Entity based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<Entity> Get(string id)
        {
            try
            {
                var request = new RestRequest($"/{Path}/{id}");
                var response = await Client.GetAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                else
                {
                    var parsedObject = JObject.Parse(response.Content);
                    var data = parsedObject["data"].ToString();
                    return JsonConvert.DeserializeObject<Entity>(data);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        /// <summary>
        /// Returns a list of  entities
        /// Currently the number of entities that is fetched is hardcoded to 20
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        public IEnumerable<Entity> List()
        {
            int list_limit = 20;
            try
            {
                var request = new RestRequest($"/{Path}?per_page={list_limit}");
                var response = Client.Get(request);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                else
                {
                    JObject parsedObject = JObject.Parse(response.Content);
                    var data = parsedObject["data"].ToString();
                    return JsonConvert.DeserializeObject<List<Entity>>(data);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }


        /// <summary>
        /// Creates a specific Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// Return \"Created\" if request was successful
        /// </returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<string> Create(Entity entity)
        {
            try
            {
                var request = new RestRequest($"api/{Path}").AddJsonBody(entity);
                var response = await Client.PostAsync(request);

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





        /// <summary>
        /// Deletes a Entity with the specific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return \"No Content\" if request was successful
        /// </returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<string> Delete(string id)
        {
            try
            {

                var request = new RestRequest($"api/{Path}/{id}");
                var response = await Client.DeleteAsync(request);
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




        /// <summary>
        /// Updates/Patches a specific Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        /// Return \"OK\" if request was successful
        /// </returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<string> Update(Entity entity)
        {
            try
            {
                var request = new RestRequest($"api/{Path}").AddJsonBody(entity);
                var response = await Client.PatchAsync(request);

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
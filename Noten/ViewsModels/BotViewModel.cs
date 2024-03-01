using Noten.Models;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Noten.ViewsModels
{
    public class BotViewModel
    {
        private string url = "http://www.stomach.com.br:8885/";
        public BotViewModel() { }

        HttpClient client = new HttpClient();

        public async Task<string> Get()
        {
            using HttpResponseMessage response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<MessageModel> GetEcho()
        {
            string response = await client.GetStringAsync(url);
            MessageModel result = JsonConvert.DeserializeObject<MessageModel>(response);
            return result;
        }

        public async Task<MessageModel> Post(MessageModel message)
        {
            string json = JsonConvert.SerializeObject(message);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await client.PostAsync(url, data);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MessageModel>(result);
        }
    }
}
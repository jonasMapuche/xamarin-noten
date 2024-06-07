using Noten.Models;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace Noten.ViewsModels
{
    public class BotViewModel
    {
        private string url = "http://www.stomach.com.br:8885/";
        public BotViewModel() { }

        HttpClient client = new HttpClient();

        public static readonly NotenViewModel _notensViewModel = new NotenViewModel();

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

        public List<string> GetChord(string initial)
        {
            ChordModel chord = _notensViewModel.GetChord(initial);
            List<string> saida = new List<string>();
            if (chord != null)
            {
                saida.Add(chord.initial.ToString());
                saida.Add(chord.name.ToString());
                chord.lyrics.ForEach(index =>
                {
                    saida.Add(index.name.ToString());
                    saida.Add(index.frequency.ToString());
                    saida.Add(index.constricted ? "corda contrita" : "corda solta");
                    saida.Add("casa " + index.home.ToString());
                    if (index.lash) saida.Add("pestana");
                    else saida.Add("dedo " + index.finger.ToString());
                });
            }
            else saida = null;
            return saida;
        }
    }
}
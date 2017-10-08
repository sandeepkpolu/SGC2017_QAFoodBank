using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace QAFoodBank
{
    public class CloudDataStore : IDataStore<Item>
    {
        HttpClient client;
        IEnumerable<Item> items;

        public CloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<Item>();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/items");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json));
            }

            return items;
        }

    }
}

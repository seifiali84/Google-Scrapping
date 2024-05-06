using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Google_Scrapping
{
    public class API
    {

        private static HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("https://serpapi.com/") };

        public static async Task<List<string>> GetImage(string SearchText)
        {
            var Res = await httpClient.GetAsync($"search.json?q={SearchText}&engine=google_images&ijn=0");
            List<string> ImagesList = new List<string>();
            if (Res.IsSuccessStatusCode)
            {
                string json = await Res.Content.ReadAsStringAsync();
                return new List<string>();
                var jsonData = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

                if (jsonData.TryGetValue("images_results", out var Images))
                {
                    if (Images is List<object> images)
                    {
                        foreach (var item in images)
                        {
                            if (item is Dictionary<string, object> imageDict)
                            {
                                // Extract data from the image dictionary (modify as needed)
                                ImagesList.Add((string)imageDict.GetValueOrDefault("original"));
                            }
                            else
                            {
                                MessageBox.Show("Bad Response");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bad Response");
                    }
                }
                else
                {
                    MessageBox.Show("Bad Response");
                }
            }
            else
            {
                MessageBox.Show(Res.StatusCode.ToString());
            }
            return ImagesList;
        }
    }
}

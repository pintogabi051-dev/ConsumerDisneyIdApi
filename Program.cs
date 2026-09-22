using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsumerDisneyIdApi
{
    // Modelo do personagem (sem espaços no nome)
    public class BigadWolf
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;
    }

    // A API envelopa a resposta dentro de "data"
    public class DisneyResponse
    {
        [JsonPropertyName("data")]
        public BigBadWolf? Data { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://api.disneyapi.dev/character/423";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonString = await response.Content.ReadAsStringAsync();

                    DisneyResponse? disneyResponse = JsonSerializer.Deserialize<DisneyResponse>(jsonString);

                    if (disneyResponse?.Data != null)
                    {
                        Console.WriteLine("Nome:");
                        Console.WriteLine(disneyResponse.Data.Name);
                        Console.WriteLine("Imagem:");
                        Console.WriteLine(disneyResponse.Data.ImageUrl);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao consumir a API: {ex.Message}");
                }
            }
        }
    }
}
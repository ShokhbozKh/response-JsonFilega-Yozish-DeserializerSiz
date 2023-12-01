using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace ConsoleApp12
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /// nbu ni jsonga yozaman
            /// 7
            /// 

            string url = @"https://nbu.uz/uz/exchange-rates/json/";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(" ");
            var deJson =  await response.Content.ReadAsStringAsync();

            await Console.Out.WriteLineAsync(deJson);

            var json = JsonSerializer.Deserialize<Nbu[]>(deJson);

            foreach(var item in json)
            {
                Console.WriteLine(item.title);
            }

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fileName = $@"{path}\\file.json";

            if(!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
            using(StreamWriter aw  = new StreamWriter(fileName))
            {
                aw.WriteLine(deJson);
            }
        }
    }
}
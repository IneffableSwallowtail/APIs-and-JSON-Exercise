using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest/";
            var swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            for (int i = 0; i < 5; i++)
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                Console.WriteLine($"Kanye: \"{kanyeQuote}\"");

                var swansonResponse = client.GetStringAsync(swansonURL).Result;
                var swansonQuote = JArray.Parse(swansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                //Wanted to use .Remove('"'), but I got an error message about startIndex not being longer than the string
                Console.WriteLine($"Swanson: {swansonQuote}");
            }
        }
    }
}
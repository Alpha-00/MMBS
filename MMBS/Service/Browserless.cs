using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Scriban.Parsing;

namespace MMBS.Service
{
    public class Browserless
    {
        const String endpoint = "https://production-sfo.browserless.io/chromium/bql";
        String key = "";
        public void init()
        {
            key = getLocalApiKey();
        }
        private const String funcGeneralFetch = @"
            mutation GeneralFetch($url: String!) {
                reject(type: [image, media, font, stylesheet]) {
                enabled
                time
              }
              goto(url: $url, waitUntil: load) {
                status
              }
              # Or export cleaned HTML with numerous options
        }";

        private const String funcCloudflareFetch = @"
            mutation GeneralFetch($url: String!) {
              goto(url: $url, waitUntil: load) {
                status
              }
              verify(type: cloudflare) {
                found
                solved
                time
              }
              solve(type: hcaptcha,timeout: 1000) {
                found
                solved
              }
              html(timeout: 500) {
                html
              }
            }";
        private const String optionsCloudflare = "const proxyString = \"&proxy=residential&proxyCountry=us\";\r\nconst optionsString = \"&humanlike=true\";";
        
        public async Task<String> fetch(String url, String query = funcGeneralFetch, String operationName = "Default",bool useProxy = false, bool useHumanBehavior = false)
        {

            if (query == "") throw new ArgumentException();
            var requestBody = new
            {
                query = query,
                variables = new
                {
                    url = url
                },
                //operationName = operationName
            };

            // Serialize the request body to JSON
            string jsonContent = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Create an HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                String proxyString = useProxy ? "&proxy=residential&proxyCountry=us" : "";
                String optionsString = useHumanBehavior ? "&humanlike=true" : "";
                // Add the token to the URL
                string requestUrl = $"{endpoint}?token={key}{proxyString}{optionsString}";

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync(requestUrl, content);

                // Ensure the request was successful
                //response.EnsureSuccessStatusCode();

                // Read the response content as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response
                //var data = JsonDocument.Parse(responseBody);
                var data = JsonNode.Parse(responseBody);

                // Print the data to the console
                Console.WriteLine(data["data"]["html"]["html"]);
                return data["data"]["html"]["html"].GetValue<string>();
            }
            return "";
        }

        public async Task<String> fetchWithCloudflareBypass(String url, String operationName = "CloudflareFetch") => await fetch(url, funcCloudflareFetch, operationName, true, true);
        /// <summary>
        /// Retrieve the local API key from storage
        /// </summary>
        /// <returns></returns>
        static String getLocalApiKey()
        {
            var key = File.ReadAllText(MMBS.Class1.GetToken("browserless"));
            return key;
        }
    }
}

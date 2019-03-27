using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ClientCredentialsAuthorization
{
    class Program
    {
        private static string Token { get; set; }

        private static string RetornoConteudoAPI { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Acesso API por credenciais para obter token de acesso");
            Console.WriteLine("===============================================================");
            Token = GetToken().Result;
            Console.WriteLine("Token de Acesso: " + Token);
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Consumir API usando o token de acesso");
            Console.WriteLine("===============================================================");
            RetornoConteudoAPI = GetAPI().Result;
            Console.WriteLine("Obter Conteúdo da API: " + RetornoConteudoAPI);
            Console.ReadKey();
        }

        /// <summary>
        /// Type Authentication: Basic(User, Password)
        /// </summary>
        /// <returns></returns>
        private static async Task<string> GetToken()
        {

            var CLIENT_ID = "YOUR CLIENT ID";
            var CLIENT_SECRET = "YOUR CLIENT SECRET";

            string credentials = String.Format("{0}:{1}", CLIENT_ID, CLIENT_SECRET);

            var url = "URL WITH CREDENTIALS";

            using (var _client = new HttpClient())
            {
                //Define Headers
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

                //Prepare Request Body
                List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
                requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

                FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

                //Request Token
                var resultCredendials = await _client.PostAsync(url, requestBody);
                var response = await resultCredendials.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<AccessToken>(response).access_token;
            }
        }


        /// <summary>
        /// Type Authentication: Bearer (OAuth 2.0)
        /// </summary>
        /// <returns></returns>
        private static async Task<string> GetAPI()
        {

            var url = "URL API - WITH ACCESS TOKEN";

            using (var _client = new HttpClient())
            {

                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token); //Token = GetToken()

                var result = await _client.GetAsync(url);

                if (result.IsSuccessStatusCode)
                {
                    var content = result.Content.ReadAsStringAsync();

                    return content.Result;
                    //return JsonConvert.DeserializeObject<"Classe para serializar o objeto Json">(content).CampoRetorno;
                }

            }

            return null;

        }

    }
}

using Itau.TheCat.Dados.Config;
using System.Net.Http.Headers;

namespace Itau.TheCat.Dados.Repositorios
{
    public class BaseHttpClient : HttpClient
    {
        public BaseHttpClient(string uri)
        {
            BaseAddress = new Uri(uri);
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

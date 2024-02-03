using Newtonsoft.Json;
using RestSharp;
using Sebrae.UI.Model;
using System.Reflection.Emit;

namespace Sebrae.UI.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /*public async Task<List<ContaViewModel>> ObterContas()
        {
            var client = new RestClient($"https://localhost:62315/Contas");
            var request = new RestRequest() { Method = Method.Get };

            var response = await client.ExecuteAsync<List<ContaViewModel>>(request);


            //var response = await _httpClient.GetAsync("/contas");

            //response.EnsureSuccessStatusCode();

            //var content = await response.Content.ReadAsStringAsync();
            return response.Data!;
        }*/

        private readonly IRestClient _restClient;

        public ApiClient(IRestClient restClient)
        {
            _restClient = restClient;
            //_restClient.UseNewtonsoftJson(); // Configuração para utilizar o Newtonsoft.Json para desserialização
        }

        public async Task<List<ContaViewModel>> ObterContas()
        {
            var request = new RestRequest("/contas");
            request.Method = Method.Get;
            var response = await _restClient.ExecuteAsync<List<ContaViewModel>>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                // Lidar com falha na requisição
                return new List<ContaViewModel>();
            }
        }

        public void CriarConta(ContaViewModel novaConta)
        {
            var request = new RestRequest("/contas");
            request.Method = Method.Post;
            request.AddJsonBody(novaConta);
            _restClient.ExecutePostAsync(request).ConfigureAwait(false);
        }

        public async Task EditarConta(ContaViewModel contaEditada)
        {
            var request = new RestRequest($"/contas/{contaEditada.Id}");
            request.Method = Method.Put;
            request.AddJsonBody(contaEditada);
            await _restClient.ExecuteAsync(request);
        }

        public async Task RemoverConta(int id)
        {
            var request = new RestRequest($"/contas/{id}");
            request.Method = Method.Delete;
            await _restClient.ExecuteAsync(request);
        }
    }
}

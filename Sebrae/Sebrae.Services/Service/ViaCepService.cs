using RestSharp;
using Sebrae.Services.Exceptions;
using Sebrae.Services.Response;

namespace Sebrae.Services.Service
{
    public class ViaCepService : IViaCepService
    {
        public async Task<RestResponse<ViaCepResponse>> GetZipCodeInformation(string zipCode)
        {
            try
            {
                var client = new RestClient($"http://viacep.com.br/ws/{zipCode}/json/");
                var request = new RestRequest() { Method = Method.Get };

                var response = await client.ExecuteAsync<ViaCepResponse>(request);

                return response;
            }
            catch (Exception ex)
            {
                throw new ViaCepException(ex.Message, ex);
            }
        }
    }
}
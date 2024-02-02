using RestSharp;
using Sebrae.Services.Response;


namespace Sebrae.Services.Service
{
    public interface IViaCepService
    {
        Task<RestResponse<ViaCepResponse>> GetZipCodeInformation(string zipCode);
    }
}

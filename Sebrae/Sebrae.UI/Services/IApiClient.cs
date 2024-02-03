using Sebrae.UI.Model;

namespace Sebrae.UI.Services
{
    public interface IApiClient
    {
        Task<List<ContaViewModel>> ObterContas();
        void CriarConta(ContaViewModel novaConta);
    }
}

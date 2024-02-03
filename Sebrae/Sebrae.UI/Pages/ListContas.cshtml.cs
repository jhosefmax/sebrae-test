using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sebrae.UI.Model;
using Sebrae.UI.Services;

namespace Sebrae.UI.Pages
{
    public class ListContasModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public List<ContaViewModel> Contas { get; set; }
        public ListContasModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public void OnGet()
        {
            Contas = _apiClient.ObterContas().Result;
        }
    }
}

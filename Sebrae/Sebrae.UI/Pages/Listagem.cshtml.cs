using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sebrae.UI.Model;
using Sebrae.UI.Services;

namespace Sebrae.UI.Pages
{
    public class ListagemModel : PageModel
    {
        public ListagemModel(IApiClient apiClient) 
        {
            _apiClient = apiClient;
        }
        public List<ContaViewModel> Contas { get; set; }

        private readonly IApiClient _apiClient;
        public void OnGet()
        {
            Contas = _apiClient.ObterContas().Result;
        }
    }
}

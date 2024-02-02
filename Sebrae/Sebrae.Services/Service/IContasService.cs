using Sebrae.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sebrae.Services.Service
{
    public interface IContasService
    {
        Task<List<Conta>> GetContas();

        Task<Conta> GetContaById(int id);

        Task CreateConta(Conta conta);

        Task UpdateConta(Conta conta);

        Task DeleteConta(int id);
    }
}

using Sebrae.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sebrae.Repository
{
    public interface IContaRepository
    {
        Task<List<Conta>> GetContasAsync();
        Task<Conta> GetContaByIdAsync(int id);
        Task CreateContaAsync(Conta conta);
        Task UpdateContaAsync(Conta conta);
        Task DeleteContaAsync(int id);
    }
}

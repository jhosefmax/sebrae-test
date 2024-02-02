using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sebrae.Persistence;
using Sebrae.Repository;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sebrae.Services.Service
{
    public class ContaService : IContasService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<List<Conta>> GetContas()
        {
            return await _contaRepository.GetContasAsync();
        }

        public async Task<Conta> GetContaById(int id)
        {
            return await _contaRepository.GetContaByIdAsync(id);
        }

        public async Task CreateConta(Conta conta)
        {
            await _contaRepository.CreateContaAsync(conta);
        }

        public async Task UpdateConta(Conta conta)
        {
            await _contaRepository.UpdateContaAsync(conta);
        }

        public async Task DeleteConta(int id)
        {
            await _contaRepository.DeleteContaAsync(id);
        }
    }
}

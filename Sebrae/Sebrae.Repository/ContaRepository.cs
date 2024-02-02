using Microsoft.EntityFrameworkCore;
using Sebrae.Persistence;


namespace Sebrae.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly ApplicationDbContext _context;

        public ContaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Conta>> GetContasAsync()
        {
            return await _context.Contas.ToListAsync();
        }

        public async Task<Conta> GetContaByIdAsync(int id)
        {
            return await _context.Contas.FindAsync(id);
        }

        public async Task CreateContaAsync(Conta conta)
        {
            _context.Contas.Add(conta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContaAsync(Conta conta)
        {
            _context.Entry(conta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContaAsync(int id)
        {
            var conta = await _context.Contas.FindAsync(id);
            if (conta != null)
            {
                _context.Contas.Remove(conta);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using shitbomber.jogo.data.Context;
using shitbomber.jogo.domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shitbomber.jogo.data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JogoContext _context;

        public UnitOfWork(JogoContext context)
        {
            _context = context;
        }

        private ITesteRepository _testeRepository;
        public ITesteRepository TesteRepository => _testeRepository ?? (_testeRepository = new TesteRepository(_context));

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

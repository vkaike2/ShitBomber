using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shitbomber.jogo.domain.IRepository
{
    public interface IUnitOfWork
    {
        ITesteRepository TesteRepository { get; }

        Task CommitAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace shitbomber.jogo.domain.IRepository
{
    public interface IRepositoryBase<Model>
    {
        void Deletar(Model model);
        Task<Model> GetUm(Expression<Func<Model, bool>> where);
        Task Inserir(Model model);
        void Atualizar(Model model);
    }
}

using shitbomber.jogo.data.Context;
using shitbomber.jogo.data.Entidades;
using shitbomber.jogo.domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Model = shitbomber.jogo.domain.Model;

namespace shitbomber.jogo.data.Repository
{
    public class TesteRepository : RepositoryBase<Model.Teste, Teste>, ITesteRepository
    {
        public TesteRepository(JogoContext context) : base(context) { }
    }
}

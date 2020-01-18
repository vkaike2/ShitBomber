using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using shitbomber.jogo.data.Context;
using shitbomber.jogo.data.Mapper;
using shitbomber.jogo.domain;
using shitbomber.jogo.domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace shitbomber.jogo.data.Repository
{
    public abstract class RepositoryBase<Model, Entidade> : IRepositoryBase<Model>
        where Model : class
        where Entidade : class
    {
        protected readonly JogoContext _dbContext;
        protected readonly IMapper _mapper;

        public RepositoryBase(JogoContext dbContext)
        {
            _dbContext = dbContext;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(MappingProfile));
            });
            _mapper = config.CreateMapper();
        }

        public async Task<Model> GetUm(Expression<Func<Model, bool>> where)
        {
            Model model = await _dbContext.Set<Entidade>().ProjectTo<Model>(_mapper.ConfigurationProvider).Where(where).FirstOrDefaultAsync();
            return model;
        }

        public void Deletar(Model model)
        {
            Entidade entidade = _mapper.Map<Entidade>(model);
            _dbContext.Set<Entidade>().Remove(entidade);
        }

        public async Task Inserir(Model model)
        {
            Entidade entidade = _mapper.Map<Entidade>(model);
            await _dbContext.Set<Entidade>().AddAsync(entidade);
        }

        public void Atualizar(Model model)
        {
            Entidade entidade = _mapper.Map<Entidade>(model);
            _dbContext.Set<Entidade>().Update(entidade);
        }
    }
}

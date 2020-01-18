using shitbomber.jogo.domain.IRepository;
using shitbomber.jogo.domain.IServiceBus;
using shitbomber.jogo.domain.IServices;
using shitbomber.jogo.domain.Model;
using shitbomber.jogo.domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shitbomber.jogo.service.Services
{
    public class TesteService : ITesteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITesteServiceBus _testeServiceBus;

        public TesteService(IUnitOfWork unitOfWork,
                            ITesteServiceBus testeServiceBus)
        {
            _unitOfWork = unitOfWork;
            _testeServiceBus = testeServiceBus;
        }

        public async Task<PadraoResponse<Teste>> DeleteTeste(Guid id)
        {
            PadraoResponse<Teste> response = new PadraoResponse<Teste>();
            if (id == Guid.Empty) throw new Exception("O CAMPO Id é obrigatório!");

            Teste modelCadastrado = await _unitOfWork.TesteRepository.GetUm(e => e.Id == id);
            _unitOfWork.TesteRepository.Deletar(modelCadastrado);
            await _unitOfWork.CommitAsync();

            response.Data = modelCadastrado;
            return response;
        }

        public async Task<PadraoResponse<Teste>> GetTeste(Guid id)
        {
            PadraoResponse<Teste> response = new PadraoResponse<Teste>();

            Teste modelCadastrado = await _unitOfWork.TesteRepository.GetUm(e => e.Id == id);
            response.Data = modelCadastrado;
            return response;
        }

        public async Task<PadraoResponse<Teste>> PostTeste(Teste model)
        {
            PadraoResponse<Teste> response = new PadraoResponse<Teste>();

            model.Id = Guid.NewGuid();
            model.NovoRegistro();
            await _unitOfWork.TesteRepository.Inserir(model);
            await _unitOfWork.CommitAsync();

            _testeServiceBus.PublishTeste(model);

            response.Data = model;
            return response;
        }

        public async Task<PadraoResponse<Teste>> PutTeste(Teste model)
        {
            PadraoResponse<Teste> response = new PadraoResponse<Teste>();

            if (model.Id == Guid.Empty) throw new Exception("O CAMPO Id é obrigatório!");

            Teste modelCadastrado = await _unitOfWork.TesteRepository.GetUm(e => e.Id == model.Id);

            if (modelCadastrado is null) throw new Exception("Manda o Id certo bobão!");

            modelCadastrado.Nome = model.Nome;

            modelCadastrado.AtualizarRegistro();
            _unitOfWork.TesteRepository.Atualizar(modelCadastrado);

            await _unitOfWork.CommitAsync();

            response.Data = modelCadastrado;
            return response;
        }
    }
}

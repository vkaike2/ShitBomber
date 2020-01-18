using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using shitbomber.jogo.domain.Model;
using shitbomber.jogo.domain.Requests;

namespace shitbomber.jogo.domain.IServices
{
    public interface ITesteService
    {
        Task<PadraoResponse<Teste>> GetTeste(Guid id);
        Task<PadraoResponse<Teste>> PostTeste(Teste model);
        Task<PadraoResponse<Teste>> PutTeste(Teste model);
        Task<PadraoResponse<Teste>> DeleteTeste(Guid id);
    }
}

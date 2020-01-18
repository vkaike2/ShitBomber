using System;
using System.Collections.Generic;
using System.Text;
using shitbomber.jogo.domain.Model;

namespace shitbomber.jogo.domain.IServiceBus
{
    public interface ITesteServiceBus
    {
        void Subscribe();
        void PublishTeste(Teste model);
    }
}

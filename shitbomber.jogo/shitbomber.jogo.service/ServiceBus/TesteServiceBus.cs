using shitbomber.jogo.domain.Extensions;
using shitbomber.jogo.domain.IServiceBus;
using shitbomber.jogo.domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace shitbomber.jogo.service.ServiceBus
{
    public class TesteServiceBus : ITesteServiceBus
    {
        private readonly IConnectionFactoryCreator _connectionFactoryCreator;

        public TesteServiceBus(IConnectionFactoryCreator connectionFactoryCreator)
        {
            _connectionFactoryCreator = connectionFactoryCreator;
        }

        public void PublishTeste(Teste model)
        {
            _connectionFactoryCreator.Publish("QUEUE_POST_TESTE", model);
        }

        public void Subscribe()
        {
            _connectionFactoryCreator.Subscribe("QUEUE_POST_TESTE", (body) =>
            {
                Teste modelRecebido = body.Deserializer<Teste>();


            });
        }
    }
}

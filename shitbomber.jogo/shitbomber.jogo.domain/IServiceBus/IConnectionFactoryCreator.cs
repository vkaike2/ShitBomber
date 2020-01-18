using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shitbomber.jogo.domain.IServiceBus
{
    public interface IConnectionFactoryCreator
    {
        void Publish(string queue, object bodyMensage);
        Task Subscribe(string queue, Action<byte[]> call);
    }
}

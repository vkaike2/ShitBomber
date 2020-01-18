using System;
using System.Collections.Generic;
using System.Text;

namespace shitbomber.jogo.domain.Requests
{
    public class PadraoResponse<T>
    {
        public int Count { get; set; }
        public string Mensagem { get; set; }
        public T Data { get; set; }
    }
}

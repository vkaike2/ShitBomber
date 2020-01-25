using System;
using System.Collections.Generic;
using System.Text;

namespace shitbomber.jogo.domain.Model
{
    public class VariasMovimentacoes
    {
        public List<MovimentacaoPlayer> PlayersList { get; set; }
    }

    public class MovimentacaoPlayer
    {
        public int Id { get; set; }
        public float ValorX { get; set; }
        public float ValorY { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace shitbomber.jogo.data.Entidades
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    }
}

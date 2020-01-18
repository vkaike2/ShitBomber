using System;

namespace shitbomber.jogo.domain.Model
{
    public abstract class ModelBase
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public void NovoRegistro()
        {
            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        public void AtualizarRegistro()
        {
            DataAtualizacao = DateTime.Now;
            Ativo = true;
        }

        public void InativarRegistro()
        {
            Ativo = false;
        }
    }
}

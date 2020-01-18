using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace shitbomber.jogo.data.Entidades
{
    [Table("tb_teste")]
    public class Teste : EntityBase
    {
        [Column("name")]
        public string Nome { get; set; }
    }
}

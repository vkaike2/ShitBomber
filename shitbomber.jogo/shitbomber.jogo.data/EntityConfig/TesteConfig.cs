using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shitbomber.jogo.data.Entidades;

namespace shitbomber.jogo.data.EntityConfig
{
    public class TesteConfig : IEntityTypeConfiguration<Teste>
    {
        public void Configure(EntityTypeBuilder<Teste> builder)
        {
            //builder.t("tb_teste");

            //builder.Property(e => e.Nome).HasColumnName("name");
        }
    }
}

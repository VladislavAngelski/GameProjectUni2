using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityTypeConfiguration
{
    public class GameExtraConfiguration : IEntityTypeConfiguration<GameExtra>
    {
        public void Configure(EntityTypeBuilder<GameExtra> builder)
        {
            builder.HasKey(tcm => new { tcm.GameId, tcm.ExtraId });

            builder.HasOne(tcm => tcm.Game)
                .WithMany(t => t.GamesExtras)
                .HasForeignKey(tcm => tcm.GameId);

            builder.HasOne(tcm => tcm.Extra)
                .WithMany(tc => tc.GamesExtras)
                .HasForeignKey(tcm => tcm.ExtraId);
        }
    }
}

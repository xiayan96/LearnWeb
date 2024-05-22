using LearnWeb.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWeb.EntityFramework.Mappings
{
    public class PlayerMap :IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player>builder)
        {
            builder.Property(player => player.Account).HasMaxLength(50);
            builder.Property(Player => Player.AccountType).HasMaxLength(10);
            builder.HasIndex(player => player.Account).IsUnique();

        }
    }
}

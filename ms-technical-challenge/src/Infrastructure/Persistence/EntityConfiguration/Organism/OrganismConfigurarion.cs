namespace SB.TechnicalChallenge.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.TechnicalChallenge.Domain;

public class OrganismConfigurarion : EntityMapBase<Person>
{
    protected override void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Organism");
        builder.Property(b => b.Name).HasMaxLength(150).IsRequired();
    }
}

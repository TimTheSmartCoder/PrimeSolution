using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitor.Domain.Entities;

namespace Monitor.Infrastructure.Configurations.EFCore
{
    public class LogInformationEntityTypeConfiguration : IEntityTypeConfiguration<LogInformation>
    {
        public void Configure(EntityTypeBuilder<LogInformation> builder)
        {
            builder.ToTable("LogInformations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ForSqlServerUseSequenceHiLo();

            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.HttpMethod).IsRequired();
            builder.Property(x => x.HttpStatus).IsRequired();
            builder.Property(x => x.Path).IsRequired();
            builder.Property(x => x.Timestamp).IsRequired();
            builder.Property(x => x.ServiceId).IsRequired();
        }
    }
}

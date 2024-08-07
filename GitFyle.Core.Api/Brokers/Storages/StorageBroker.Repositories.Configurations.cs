﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using GitFyle.Core.Api.Models.Foundations.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GitFyle.Core.Api.Brokers.Storages
{
    internal partial class StorageBroker
    {
        void AddRepositoryConfigurations(EntityTypeBuilder<Repository> builder)
        {
            builder
                .Property(repository => repository.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(repository => repository.Owner)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(repository => repository.ExternalId)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(repository => repository.SourceId)
                .IsRequired();

            builder.HasIndex(repository => new
            {
                repository.Name,
                repository.Owner,
                repository.ExternalId,
                repository.SourceId
            });

            builder.HasOne(repository => repository.Source)
                .WithMany(source => source.Repositories)
                .HasForeignKey(repository => repository.SourceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}



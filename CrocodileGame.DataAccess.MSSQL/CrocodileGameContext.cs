using CrocodileGame.DataAccess.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CrocodileGame.DataAccess.PostgreSQL
{
    public class CrocodileGameContext : DbContext
    {
        public CrocodileGameContext(DbContextOptions<CrocodileGameContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder
                .Entity<CardTopic>()
                .HasOne<Topic>(ct => ct.Topic)
                .WithMany(t => t.CardTopics)
                .HasForeignKey(t => t.TopicId);

            modelBuilder
                .Entity<CardTopic>()
                .HasOne<Card>(ct => ct.Card)
                .WithMany(c => c.CardTopics)
                .HasForeignKey(c => c.CardId);

            modelBuilder.Entity<Card>()
                .HasData(new[]
                {
                    new Card
                    { 
                        Id = 1,
                        Word = "monkey"
                    },
                    new Card
                    {
                        Id = 2,
                        Word = "ball"
                    },
                    new Card
                    {
                        Id = 3,
                        Word = "apple"
                    }
                });

            modelBuilder.Entity<Topic>()
                .HasData(new[]
                {
                    new Topic
                    {
                        Id = 1,
                        Name = "animals"
                    },
                    new Topic
                    {
                        Id = 2,
                        Name = "toys"
                    },
                    new Topic
                    {
                        Id = 3,
                        Name = "food"
                    }
                });

            modelBuilder.Entity<CardTopic>()
                .HasData(new[]
                {
                    new CardTopic
                    {
                        Id = 1,
                        CardId = 1,
                        TopicId = 1
                    },
                    new CardTopic
                    {
                        Id = 2,
                        CardId = 2,
                        TopicId = 2
                    },
                    new CardTopic
                    {
                        Id = 3,
                        CardId = 3,
                        TopicId = 3
                    },
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Card> Cards { get; set;}
        public DbSet<Topic> Topics { get; set; }
        public DbSet<CardTopic> CardTopics { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using RailroadTransport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RailroadTransport.Data
{
    public class RailroadContext : DbContext
    {
        public RailroadContext(DbContextOptions<RailroadContext> options) : base(options) { }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PK__Schedule__A532EDD4B032E1B3");

                entity.Property(e => e.ScheduleId).HasColumnName("scheduleId");

                entity.Property(e => e.BeginStopId).HasColumnName("beginStopId");

                entity.Property(e => e.Day)
                    .HasColumnName("day")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.EndStopId).HasColumnName("endStopId");

                entity.Property(e => e.TimeOfArrive).HasColumnName("timeOfArrive");

                entity.Property(e => e.TrainId).HasColumnName("trainId");

                entity.HasOne(d => d.BeginStop)
                    .WithMany(p => p.ScheduleBeginStop)
                    .HasForeignKey(d => d.BeginStopId)
                    .HasConstraintName("FK__Schedules__begin__31EC6D26");

                entity.HasOne(d => d.EndStop)
                    .WithMany(p => p.ScheduleEndStop)
                    .HasForeignKey(d => d.EndStopId)
                    .HasConstraintName("FK__Schedules__endSt__32E0915F");

                entity.HasOne(d => d.Train)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.TrainId)
                    .HasConstraintName("FK__Schedules__train__30F848ED");
            });
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TouristInformation.Data.Identity;

namespace TouristInformation.Data.Models;

public partial class TouristInformationContext : IdentityDbContext<ApplicationUser>
{
    public TouristInformationContext()
    {
    }

    public TouristInformationContext(DbContextOptions<TouristInformationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attraction> Attractions { get; set; }

    public virtual DbSet<ReservedTicket> ReservedTickets { get; set; }
    //public object Attraction { get; internal set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("name=constring");

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
        //modelBuilder.Entity<Attraction>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK__attracti__3213E83FBC679E51");

        //    entity.ToTable("attractions");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.AttrName)
        //        .HasMaxLength(80)
        //        .IsUnicode(false)
        //        .HasColumnName("attr_name");
        //    entity.Property(e => e.Category)
        //        .HasMaxLength(30)
        //        .IsUnicode(false)
        //        .HasColumnName("category");
        //    entity.Property(e => e.City)
        //        .HasMaxLength(30)
        //        .IsUnicode(false)
        //        .HasColumnName("city");
        //    entity.Property(e => e.Duration).HasColumnName("duration");
        //    entity.Property(e => e.Latitude).HasColumnName("latitude");
        //    entity.Property(e => e.Longitude).HasColumnName("longitude");
        //    entity.Property(e => e.Price).HasColumnName("price");
        //    entity.Property(e => e.RecommendedAge).HasColumnName("recommended_age");
        //});

        //modelBuilder.Entity<ReservedTicket>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK__reserved__3213E83F59A1ABD8");

        //    entity.ToTable("reserved_tickets");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.AttrId).HasColumnName("attr_id");
        //    entity.Property(e => e.GuestName)
        //        .HasMaxLength(100)
        //        .IsUnicode(false)
        //        .HasColumnName("guest_name");
        //    entity.Property(e => e.Quantity).HasColumnName("quantity");

        //    entity.HasOne(d => d.Attr).WithMany(p => p.ReservedTickets)
        //        .HasForeignKey(d => d.AttrId)
        //        .HasConstraintName("FK__reserved___attr___4BAC3F29");
        //});

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

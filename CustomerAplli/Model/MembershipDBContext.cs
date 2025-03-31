using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CustomerAplli.Model
{
    public class MembershipDBContext : DbContext
    {
        public MembershipDBContext()
        {
        }

        public MembershipDBContext(DbContextOptions<MembershipDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>(entity =>
        //    {
        //        entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC076C1DB895");

        //        entity.ToTable("Customer");

        //        entity.Property(e => e.Name)
        //            .HasMaxLength(20)
        //            .IsUnicode(false);
        //    });
        //}

    }
}

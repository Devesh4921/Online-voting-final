using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_voting.Areas.Identity.Data;
using Online_voting.Models;

public class ApplicationDbContext : IdentityDbContext<Online_votingUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Add DbSet properties for your models
    public DbSet<Election> Elections { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Voter> Voters { get; set; }
    public DbSet<Vote> Votes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships
        modelBuilder.Entity<Candidate>()
            .HasOne(c => c.Election)
            .WithMany(e => e.Candidates)
            .HasForeignKey(c => c.ElectionId);

        modelBuilder.Entity<Vote>()
            .HasOne(v => v.Candidate)
            .WithMany()
            .HasForeignKey(v => v.CandidateId);

        modelBuilder.Entity<Vote>()
            .HasOne(v => v.Voter)
            .WithMany(v => v.Votes)
            .HasForeignKey(v => v.VoterId);
    }
}
using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DataLayer
{
    public class ProjectDBContext : IdentityDbContext<IdentityUser>
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options)
        {
            // this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-3P4J0S4;Initial Catalog=VacationManager;Integrated Security=true;Trust Server Certificate = true;");
            //optionsBuilder.UseSqlServer(@"Server=;Database=;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Server=;Database=;Trusted_Connection=True;");
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseMySQL("Server=127.0.0.1;Database=VacationManager777777;Uid=root;Pwd=QuizG@m3;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<VacationDoc>()
                .Property(vd => vd.ImageOfDoc)
                .HasColumnType("longblob");*/
          
          /*  modelBuilder.Entity<Team>(team =>
            {
                team.HasKey(t => t.ID);
                team.HasOne(t => t.TeamLeader)
                    .WithOne(tl => tl.Team)
                    .HasForeignKey<TeamLeader>(tl => tl.TeamId);
            });

            modelBuilder.Entity<Worker>(worker =>
            {
                worker.HasKey(w => w.Id);
                worker.HasOne(w => w.Team)
                    .WithMany(t => t.Workers)
                    .HasForeignKey(w => w.TeamId);
            });
          */

            modelBuilder.Entity<Worker>().ToTable("Workers");
            modelBuilder.Entity<TeamLeader>().ToTable("TeamLeaders");
            modelBuilder.Entity<CEO>().ToTable("CEOs");
        } 
        public DbSet<Team> Teams { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<TeamLeader> TeamLeaders { get; set; }
        public DbSet<CEO> CEOs { get; set; }
        public DbSet<VacationDoc> VacationDocs { get; set; }
    }
}

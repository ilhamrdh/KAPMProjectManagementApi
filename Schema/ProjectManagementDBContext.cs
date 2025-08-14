using KAPMProjectManagementApi.Emun;
using KAPMProjectManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KAPMProjectManagementApi.Schema
{
    public class ProjectManagementDBContext : DbContext
    {
        public ProjectManagementDBContext(DbContextOptions<ProjectManagementDBContext> options) : base(options) { }

        public DbSet<MstProjectManager> MstProjectManager { get; set; }
        public DbSet<MstUnitProject> MstUnitProject { get; set; }
        public DbSet<TrnProject> TrnProject { get; set; }
        public DbSet<MstEmployee> MstEmployee { get; set; }
        public DbSet<MstRoleProject> MstRoleProject { get; set; }
        public DbSet<TrnProjectAdendum> TrnProjectAdendum { get; set; }
        public DbSet<TrnProjectIssue> TrnProjectIssue { get; set; }
        public DbSet<TrnProjectReport> TrnProjectReport { get; set; }
        public DbSet<TrnProjectReportDtl> TrnProjectReportDtl { get; set; }
        public DbSet<TrnProjectSO> TrnProjectSO { get; set; }
        public DbSet<TrnProjectTimeline> TrnProjectTimeline { get; set; }
        public DbSet<TrnScheduleInvoice> TrnScheduleInvoice { get; set; }
        public DbSet<TrnSapWbs> TrnSapWbs { get; set; }
        public DbSet<TrnSapHrd> TrnSapHrd { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MstProjectManager>()
            .HasKey(e => new { e.Id, e.Nipp });

            modelBuilder.Entity<MstUnitProject>()
            .HasKey(e => new { e.Id, e.UnitProject });

            modelBuilder.Entity<TrnProject>()
            .HasKey(e => new { e.Id, e.ProjectDef });

            modelBuilder.Entity<MstEmployee>()
            .HasKey(e => new { e.Id, e.Nipp });

            modelBuilder.Entity<MstRoleProject>()
            .HasKey(e => new { e.Id, e.RoleId });

            modelBuilder.Entity<TrnProjectAdendum>()
            .HasKey(e => new { e.Id });

            modelBuilder.Entity<TrnProjectIssue>()
            .HasKey(e => new { e.Id, e.NoIssue });

            modelBuilder.Entity<TrnProjectReport>()
            .HasKey(e => new { e.Id, e.WeekNo });

            modelBuilder.Entity<TrnProjectReportDtl>()
            .HasKey(e => new { e.Id, e.NoSr });

            modelBuilder.Entity<TrnProjectSO>()
            .HasKey(e => new { e.Id });

            modelBuilder.Entity<TrnProjectTimeline>()
            .HasKey(e => new { e.Id, e.WBSElement });

            modelBuilder.Entity<TrnScheduleInvoice>()
            .HasKey(e => new { e.Id, e.No });

            modelBuilder.Entity<TrnSapWbs>()
            .HasKey(e => new { e.Id, e.WBSElement });

            modelBuilder.Entity<TrnSapHrd>()
            .HasKey(e => new { e.Id, e.ProjectDef });


            // enum
            modelBuilder.Entity<TrnProject>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<EProjectStatus>(v))
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<TrnProjectTimeline>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<EProjectTimeline>(v))
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<MstRoleProject>()
                .Property(e => e.RoleType)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<EProjectRole>(v))
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<TrnProjectIssue>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<EProjectIssue>(v))
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<TrnProjectReportDtl>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<EProjectReportDtl>(v))
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<TrnProjectReport>()
                .Property(e => e.Deviation)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<ETypeDeviation>(v))
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<TrnProjectAdendum>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<EProjectAdendum>(v))
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<TrnScheduleInvoice>()
                .Property(e => e.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<ETypeInvoice>(v))
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<TrnScheduleInvoice>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<EStatusInvoice>(v))
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<TrnProject>()
                .HasOne(p => p.MstUnitProject)
                .WithMany(u => u.TrnProjects)
                .HasForeignKey(p => p.ProjectProfile)
                .HasPrincipalKey(u => u.UnitProject)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<MstProjectManager>()
                .HasOne(pm => pm.TrnProject)
                .WithOne(p => p.MstProjectManager)
                .HasForeignKey<TrnProject>(p => p.ProjectResponsible)
                .HasPrincipalKey<MstProjectManager>(pm => pm.Nipp)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnScheduleInvoice>()
                .HasOne(s => s.TrnProject)
                .WithMany(p => p.TrnScheduleInvoice)
                .HasForeignKey(s => s.ProjectDef)
                .HasPrincipalKey(p => p.ProjectDef)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TrnProjectAdendum>()
                .HasOne(p => p.TrnProject)
                .WithMany(pa => pa.TrnProjectAdendums)
                .HasForeignKey(p => p.ProjectDef)
                .HasPrincipalKey(pa => pa.ProjectDef)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnProjectAdendum>()
                .HasOne(pl => pl.TrnProjectTimeline)
                .WithMany(pa => pa.TrnProjectAdendums)
                .HasForeignKey(pl => pl.WBSElement)
                .HasPrincipalKey(pa => pa.WBSElement)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnProjectReport>()
                .HasOne(p => p.TrnProject)
                .WithMany(pr => pr.TrnProjectReports)
                .HasForeignKey(p => p.ProjectDef)
                .HasPrincipalKey(pr => pr.ProjectDef)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnProjectSO>()
                .HasOne(p => p.TrnProject)
                .WithMany(ps => ps.TrnProjectSOs)
                .HasForeignKey(p => p.ProjectDef)
                .HasPrincipalKey(ps => ps.ProjectDef)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnProjectSO>()
                .HasOne(rp => rp.MstRoleProject)
                .WithMany(ps => ps.ProjectSOs)
                .HasForeignKey(rp => rp.RoleId)
                .HasPrincipalKey(ps => ps.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MstEmployee>()
                .HasOne(e => e.TrnProjectSO)
                .WithOne(ps => ps.MstEmployee)
                .HasForeignKey<TrnProjectSO>(e => e.Nipp)
                .HasPrincipalKey<MstEmployee>(ps => ps.Nipp)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnProjectTimeline>()
                .HasOne(p => p.TrnProject)
                .WithMany(pt => pt.TrnProjectTimelines)
                .HasForeignKey(p => p.ProjectDef)
                .HasPrincipalKey(pt => pt.ProjectDef)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnProjectReportDtl>()
                .HasOne(pr => pr.TrnProjectReport)
                .WithMany(prd => prd.TrnProjectReportDtls)
                .HasForeignKey(pr => pr.WeekNo)
                .HasPrincipalKey(prd => prd.WeekNo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnProjectReportDtl>()
                .HasOne(p => p.TrnProject)
                .WithMany(prd => prd.TrnProjectReportDtls)
                .HasForeignKey(p => p.ProjectDef)
                .HasPrincipalKey(prd => prd.ProjectDef)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnProjectReportDtl>()
                .HasOne(pl => pl.TrnProjectTimeline)
                .WithMany(prd => prd.TrnProjectReportDtls)
                .HasForeignKey(pl => pl.WBSElement)
                .HasPrincipalKey(prd => prd.WBSElement)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnProjectIssue>()
                .HasOne(p => p.TrnProject)
                .WithMany(pi => pi.TrnProjectIssues)
                .HasForeignKey(p => p.ProjectDef)
                .HasPrincipalKey(pi => pi.ProjectDef)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnProjectIssue>()
                .HasOne(pr => pr.TrnProjectReport)
                .WithMany(pi => pi.TrnProjectIssues)
                .HasForeignKey(pr => pr.WeekNo)
                .HasPrincipalKey(pi => pi.WeekNo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrnProjectIssue>()
                .HasOne(prd => prd.TrnProjectReportDtl)
                .WithMany(pi => pi.TrnProjectIssues)
                .HasForeignKey(prd => prd.NoSr)
                .HasPrincipalKey(prd => prd.NoSr)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
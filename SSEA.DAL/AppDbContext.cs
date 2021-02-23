using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities;
using SSEA.DAL.Entities.Auth;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Entities.System;

namespace SSEA.DAL
{
    public class AppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        #region DbSets

        public DbSet<Producer> Producers { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<AccessPoint> AccessPoints { get; set; }
        public DbSet<SafetyFunction> SafetyFunctions { get; set; }
        public DbSet<Subsystem> Subsystems { get; set; }
        public DbSet<Element> Elements { get; set; }

        public DbSet<AccessPointSafetyFunction> AccessPointSafetyFunctions { get; set; }
        public DbSet<SafetyFunctionSubsystem> SafetyFunctionSubsystems { get; set; }
        public DbSet<ElementSFF> ElementSFFs { get; set; }
        public DbSet<MachineNorm> MachineNorms { get; set; }
        public DbSet<SubsystemCCF> SubsystemCCFs { get; set; }

        public DbSet<CCF> CCFs { get; set; }
        public DbSet<DC> DCs { get; set; }
        public DbSet<EvaluationMethod> EvaluationMethods { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        public DbSet<Norm> Norms { get; set; }
        public DbSet<TypeOfFunction> TypeOfFunctions { get; set; }
        public DbSet<TypeOfLogic> TypeOfLogics { get; set; }
        public DbSet<TypeOfSubsystem> TypeOfSubsystems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<F> Fs { get; set; }
        public DbSet<P> Ps { get; set; }
        public DbSet<S> Ss { get; set; }
        public DbSet<MTTFd> MTTFds { get; set; }
        public DbSet<PerformanceLevel> PerformanceLevels { get; set; }
        public DbSet<Architecture> Architectures { get; set; }
        public DbSet<Av> Avs { get; set; }
        public DbSet<CFF> CFFs { get; set; }
        public DbSet<Fr> Frs { get; set; }
        public DbSet<PFHd> PFHds { get; set; }
        public DbSet<Pr> Prs { get; set; }
        public DbSet<Se> Ses { get; set; }
        public DbSet<SFF> SFFs { get; set; }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StateTransition> StateTransitions { get; set; }

        #endregion

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.Entity is IExtendedEntityBase && (e.State == EntityState.Added || e.State == EntityState.Modified))
                                       .ToList();

            foreach (var entry in entries)
            {
                // Existing entity was modified
                if (entry.State.Equals(EntityState.Modified))
                {
                    entry.Property("DT_updated").CurrentValue = DateTime.Now;
                }
                // New entity was added
                else
                {
                    entry.Property("DT_created").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine)
                          .EnableSensitiveDataLogging()
                          .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User can have many UserClaims
            // User can have many UserLogins
            // User can have many UserTokens
            // Role can have many RoleClaims
            // User can have many Roles, one Role can be associated with many Users (UserRole = join table)

            builder.Entity<UserClaim>().ToTable("SY_UserClaim");
            builder.Entity<UserRole>().ToTable("SY_UserRole");
            builder.Entity<UserLogin>().ToTable("SY_UserLogin");
            builder.Entity<RoleClaim>().ToTable("SY_RoleClaim");
            builder.Entity<UserToken>().ToTable("SY_UserToken");

            builder.Entity<Role>(r =>
            {
                r.ToTable("SY_Role");
                r.Property(r => r.Name)
                 .IsRequired();
            });

            builder.Entity<User>(u =>
            {
                u.ToTable("SY_User");
                u.Property(u => u.Email)
                 .IsRequired();

                u.HasOne(u => u.CurrentState)
                 .WithMany();
            });

            builder.Entity<AccessPointSafetyFunction>(apsf =>
            {
                apsf.HasKey(apsf => new { apsf.AccessPointId, apsf.SafetyFunctionId });

                apsf.HasOne(apsf => apsf.SafetyFunction)
                    .WithMany(sf => sf.AccessPointSafetyFunctions)
                    .HasForeignKey(apsf => apsf.SafetyFunctionId)
                    .OnDelete(DeleteBehavior.Cascade);

                apsf.HasOne(apsf => apsf.AccessPoint)
                    .WithMany(ap => ap.AccessPointSafetyFunctions)
                    .HasForeignKey(apsf => apsf.AccessPointId)
                    .OnDelete(DeleteBehavior.Cascade);

                apsf.Property(apsf => apsf.SafetyFunctionId)
                    .HasColumnName("SafetyFunction_Id");

                apsf.Property(apsf => apsf.AccessPointId)
                    .HasColumnName("AccessPoint_Id");
            });

            builder.Entity<SafetyFunctionSubsystem>(sfs =>
            {
                sfs.HasKey(sfs => new { sfs.SafetyFunctionId, sfs.SubsystemId });

                sfs.HasOne(sfs => sfs.Subsystem)
                   .WithMany(s => s.SafetyFunctionSubsystems)
                   .HasForeignKey(sfs => sfs.SubsystemId)
                   .OnDelete(DeleteBehavior.Cascade);

                sfs.HasOne(sfs => sfs.SafetyFunction)
                   .WithMany(sf => sf.SafetyFunctionSubsystems)
                   .HasForeignKey(sfs => sfs.SafetyFunctionId)
                   .OnDelete(DeleteBehavior.Cascade);

                sfs.Property(sfs => sfs.SubsystemId)
                   .HasColumnName("Subsystem_Id");

                sfs.Property(sfs => sfs.SafetyFunctionId)
                   .HasColumnName("SafetyFunction_Id");
            });

            builder.Entity<Machine>(m =>
            {
                m.HasOne(m => m.Producer)
                 .WithMany(p => p.Machines)
                 .OnDelete(DeleteBehavior.Restrict);

                m.HasMany(m => m.AccessPoints)
                 .WithOne(a => a.Machine)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);

                m.HasOne(m => m.EvaluationMethod)
                 .WithMany(em => em.Machines)
                 .OnDelete(DeleteBehavior.Restrict);

                m.HasOne(m => m.MachineType)
                 .WithMany(mt => mt.Machines)
                 .OnDelete(DeleteBehavior.Restrict);

                m.HasOne(m => m.TypeOfLogic)
                 .WithMany(t => t.Machines)
                 .OnDelete(DeleteBehavior.Restrict);

                m.HasOne(m => m.CurrentState)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);

                m.HasOne(m => m.CurrentState)
                 .WithMany();
            });

            builder.Entity<AccessPoint>(ap =>
            {
                ap.HasOne(ap => ap.CurrentState)
                  .WithMany()
                  .OnDelete(DeleteBehavior.Cascade);

                ap.HasOne(ap => ap.CurrentState)
                  .WithMany();
            });

            builder.Entity<SafetyFunction>(sf =>
            {
                sf.HasOne(sf => sf.TypeOfFunction)
                  .WithMany(tof => tof.SafetyFunctions)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.EvaluationMethod)
                  .WithMany(em => em.SafetyFunctions)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.PLr)
                  .WithMany(pl => pl.SafetyFunctionsPLr)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.PLresult)
                  .WithMany(pl => pl.SafetyFunctionsPLresult)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.S)
                  .WithMany(s => s.SafetyFunctions)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.F)
                  .WithMany(f => f.SafetyFunctions)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.P)
                  .WithMany(p => p.SafetyFunctions)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.SILCL)
                  .WithMany(p => p.SafetyFunctionsSILCL)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.SILresult)
                  .WithMany(p => p.SafetyFunctionsSILresult)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.Se)
                  .WithMany(s => s.SafetyFunctions)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.Fr)
                  .WithMany(f => f.SafetyFunctions)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.Pr)
                  .WithMany(p => p.SafetyFunctions)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.Av)
                  .WithMany(a => a.SafetyFunctions)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.CurrentState)
                  .WithMany()
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.CurrentState)
                  .WithMany();
            });

            builder.Entity<Subsystem>(s =>
            {
                s.HasMany(s => s.Elements)
                 .WithOne(e => e.Subsystem)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);

                s.HasOne(s => s.TypeOfSubsystem)
                 .WithMany(t => t.Subsystems)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.MTTFdResult)
                 .WithMany(m => m.Subsystems)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.DCresult)
                 .WithMany(d => d.Subsystems)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.PLresult)
                 .WithMany(p => p.Subsystems)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.Architecture)
                 .WithMany(a => a.Subsystems)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.PFHdResult)
                 .WithMany(p => p.Subsystems)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.CFF)
                 .WithMany(c => c.Subsystems)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.Category)
                 .WithMany(c => c.Subsystems)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.CurrentState)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.CurrentState)
                 .WithMany();
            });

            builder.Entity<Element>(e =>
            {
                e.HasOne(e => e.Producer)
                 .WithMany(p => p.Elements)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.DC)
                 .WithMany(d => d.Elements)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.MTTFdResult)
                 .WithMany(m => m.Elements)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.CurrentState)
                 .WithMany()
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.CurrentState)
                 .WithMany();
            });

            builder.Entity<Producer>(p =>
            {
                p.HasOne(p => p.CurrentState)
                 .WithMany();
            });

            builder.Entity<SubsystemCCF>(sc =>
            {
                sc.HasKey(sc => new { sc.SubsystemId, sc.CCFId });

                sc.HasOne(sc => sc.CCF)
                  .WithMany(c => c.SubsystemCCFs)
                  .HasForeignKey(sc => sc.CCFId)
                  .OnDelete(DeleteBehavior.Cascade);

                sc.HasOne(sc => sc.Subsystem)
                  .WithMany(s => s.SubsystemCCFs)
                  .HasForeignKey(sc => sc.SubsystemId)
                  .OnDelete(DeleteBehavior.Cascade);

                sc.Property(sc => sc.SubsystemId)
                  .HasColumnName("Subsystem_Id");

                sc.Property(sc => sc.CCFId)
                  .HasColumnName("CCF_Id");
            });

            builder.Entity<ElementSFF>(es =>
            {
                es.HasKey(es => new { es.ElementId, es.SFFId });

                es.HasOne(es => es.SFF)
                  .WithMany(s => s.ElementSFFs)
                  .HasForeignKey(es => es.SFFId)
                  .OnDelete(DeleteBehavior.Cascade);

                es.HasOne(es => es.Element)
                  .WithMany(e => e.ElementSFFs)
                  .HasForeignKey(es => es.ElementId)
                  .OnDelete(DeleteBehavior.Cascade);

                es.Property(es => es.ElementId)
                  .HasColumnName("Element_Id");

                es.Property(es => es.SFFId)
                  .HasColumnName("SFF_Id");
            });

            builder.Entity<Architecture>(a =>
            {
                a.HasOne(a => a.MaxPFHd)
                 .WithMany(p => p.Architectures)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Category>(c =>
            {
                c.HasOne(c => c.MaxMTTFd)
                 .WithMany()
                 .HasForeignKey(c => c.MaxMTTFdId)
                 .OnDelete(DeleteBehavior.Restrict);

                c.HasOne(c => c.MinMTTFd)
                 .WithMany()
                 .HasForeignKey(c => c.MinMTTFdId)
                 .OnDelete(DeleteBehavior.Restrict);

                c.HasOne(c => c.MinDC)
                 .WithMany()
                 .HasForeignKey(c => c.MinDCId)
                 .OnDelete(DeleteBehavior.Restrict);

                c.HasOne(c => c.MaxDC)
                 .WithMany()
                 .HasForeignKey(c => c.MaxDCId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TypeOfLogic>(tol =>
            {
                tol.HasOne(tol => tol.MaxPL)
                   .WithMany(p => p.TypeOfLogics)
                   .OnDelete(DeleteBehavior.Restrict);

                tol.HasOne(tol => tol.MaxCategory)
                   .WithMany(c => c.TypeOfLogics)
                   .OnDelete(DeleteBehavior.Restrict);

                tol.HasOne(tol => tol.MaxSIL)
                   .WithMany(s => s.TypeOfLogics)
                   .OnDelete(DeleteBehavior.Restrict);

                tol.HasOne(tol => tol.MaxArchitecture)
                   .WithMany(a => a.TypeOfLogics)
                   .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<MachineNorm>(mn =>
            {
               mn.HasKey(mn => new { mn.MachineId, mn.NormId });

               mn.HasOne(mn => mn.Norm)
                 .WithMany(n => n.MachineNorms)
                 .HasForeignKey(mn => mn.NormId)
                 .OnDelete(DeleteBehavior.Cascade);

               mn.HasOne(mn => mn.Machine)
                 .WithMany(m => m.MachineNorms)
                 .HasForeignKey(mn => mn.MachineId)
                 .OnDelete(DeleteBehavior.Cascade);

               mn.Property(mn => mn.NormId)
                 .HasColumnName("Norm_Id");

               mn.Property(mn => mn.MachineId)
                 .HasColumnName("Machine_Id");
            });

            builder.Entity<Entity>(e =>
            {
                e.HasMany(e => e.States)
                 .WithOne(s => s.Entity)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<StateTransition>(st =>
            {
                st.HasOne(st => st.CurrentState)
                  .WithMany(cs => cs.CurrentStateTransitions)
                  .OnDelete(DeleteBehavior.Restrict);

                st.HasOne(st => st.NextState)
                  .WithMany(ns => ns.NextStateTransitions)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            builder.SeedData();
        }
    }
}

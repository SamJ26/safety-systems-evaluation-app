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
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics;
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
        public DbSet<PL> PLs { get; set; }
        public DbSet<Architecture> Architectures { get; set; }
        public DbSet<Av> Avs { get; set; }
        public DbSet<CFF> CFFs { get; set; }
        public DbSet<Fr> Frs { get; set; }
        public DbSet<HFT> HFTs { get; set; }
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

            builder.Entity<User>().ToTable("SY_User");
            builder.Entity<Role>().ToTable("SY_Role");
            builder.Entity<UserClaim>().ToTable("SY_UserClaim");
            builder.Entity<UserRole>().ToTable("SY_UserRole");
            builder.Entity<UserLogin>().ToTable("SY_UserLogin");
            builder.Entity<RoleClaim>().ToTable("SY_RoleClaim");
            builder.Entity<UserToken>().ToTable("SY_UserToken");

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
            });

            builder.Entity<SafetyFunctionSubsystem>(sfs =>
            {
                sfs.HasKey(sfs => new { sfs.SafetyFunctionId, sfs.SubsystemId });

                sfs.HasOne(sfs => sfs.Subsystem)
                   .WithMany(s => s.SafetyFunctionSubsystems)
                   .HasForeignKey(sfs => sfs.SubsystemId);

                sfs.HasOne(sfs => sfs.SafetyFunction)
                   .WithMany(sf => sf.SafetyFunctionSubsystems)
                   .HasForeignKey(sfs => sfs.SafetyFunctionId);
            });

            builder.Entity<Machine>(m =>
            {
                m.HasOne(m => m.Producer)
                 .WithMany(p => p.Machines);

                m.HasMany(m => m.AccessPoints)
                 .WithOne(a => a.Machine);

                m.HasOne(m => m.EvaluationMethod)
                 .WithMany(em => em.Machines);

                m.HasOne(m => m.MachineType)
                 .WithMany(mt => mt.Machines);

                m.HasOne(m => m.TypeOfLogic)
                 .WithMany(t => t.Machines);
            });

            builder.Entity<SafetyFunction>(sf =>
            {
                sf.HasOne(sf => sf.TypeOfFunction)
                  .WithMany(tof => tof.SafetyFunctions);

                sf.HasOne(sf => sf.EvaluationMethod)
                  .WithMany(em => em.SafetyFunctions);

                sf.HasOne(sf => sf.PLr)
                  .WithMany(pl => pl.SafetyFunctions_PLr);

                sf.HasOne(sf => sf.PL_result)
                  .WithMany(pl => pl.SafetyFunctions_PL_result);

                sf.HasOne(sf => sf.S)
                  .WithMany(s => s.SafetyFunctions);

                sf.HasOne(sf => sf.F)
                  .WithMany(f => f.SafetyFunctions);

                sf.HasOne(sf => sf.P)
                  .WithMany(p => p.SafetyFunctions);

                sf.HasOne(sf => sf.SILCL)
                  .WithMany(p => p.SafetyFunctions_SILCL);

                sf.HasOne(sf => sf.SIL_result)
                  .WithMany(p => p.SafetyFunctions_SIL_result);

                sf.HasOne(sf => sf.Se)
                  .WithMany(s => s.SafetyFunctions);

                sf.HasOne(sf => sf.Fr)
                  .WithMany(f => f.SafetyFunctions);

                sf.HasOne(sf => sf.Pr)
                  .WithMany(p => p.SafetyFunctions);

                sf.HasOne(sf => sf.Av)
                  .WithMany(a => a.SafetyFunctions);
            });

            builder.Entity<Subsystem>(s =>
            {
                s.HasMany(s => s.Elements)
                 .WithOne(e => e.Subsystem);

                s.HasOne(s => s.TypeOfSubsystem)
                 .WithMany(t => t.Subsystems);

                s.HasOne(s => s.MTTFd_result)
                 .WithMany(m => m.Subsystems);

                s.HasOne(s => s.DC_result)
                 .WithMany(d => d.Subsystems);

                s.HasOne(s => s.PL_result)
                 .WithMany(p => p.Subsystems);

                s.HasOne(s => s.Architecture)
                 .WithMany(a => a.Subsystems);

                s.HasOne(s => s.HFT)
                 .WithMany(h => h.Subsystems);

                s.HasOne(s => s.PFHd_result)
                 .WithMany(p => p.Subsystems);

                s.HasOne(s => s.CFF)
                 .WithMany(c => c.Subsystems);

                s.HasOne(s => s.Category)
                 .WithMany(c => c.Subsystems);
            });

            builder.Entity<Element>(e =>
            {
                e.HasOne(e => e.Producer)
                 .WithMany(p => p.Elements);

                e.HasOne(e => e.Subsystem)
                 .WithMany(s => s.Elements);

                e.HasOne(e => e.DC)
                 .WithMany(d => d.Elements);

                e.HasOne(e => e.MTTFd_result)
                 .WithMany(m => m.Elements);
            });

            builder.Entity<SubsystemCCF>(sc =>
            {
                sc.HasKey(sc => new { sc.SubsystemId, sc.CCF_Id });

                sc.HasOne(sc => sc.CCF)
                  .WithMany(c => c.SubsystemCCFs)
                  .HasForeignKey(sc => sc.CCF_Id);

                sc.HasOne(sc => sc.Subsystem)
                  .WithMany(s => s.SubsystemCCFs)
                  .HasForeignKey(sc => sc.SubsystemId);
            });

            builder.Entity<ElementSFF>(es =>
            {
                es.HasKey(es => new { es.ElementId, es.SFF_Id });

                es.HasOne(es => es.SFF)
                  .WithMany(s => s.ElementSFFs)
                  .HasForeignKey(es => es.SFF_Id);

                es.HasOne(es => es.Element)
                  .WithMany(e => e.ElementSFFs)
                  .HasForeignKey(es => es.ElementId);
            });

            builder.Entity<Architecture>(a =>
            {
                a.HasOne(a => a.HFT)
                 .WithMany(h => h.Architectures);

                a.HasOne(a => a.PFHd_max)
                 .WithMany(p => p.Architectures);
            });

            builder.Entity<Category>(c =>
            {
                c.HasOne(c => c.MTTFd_max)
                 .WithMany(m => m.Categories_MTTFd_max)
                 .OnDelete(DeleteBehavior.Restrict);

                c.HasOne(c => c.MTTFd_min)
                 .WithMany(m => m.Categories_MTTFd_min)
                 .OnDelete(DeleteBehavior.Restrict);

                c.HasOne(c => c.DC_min)
                 .WithMany(dc => dc.Categories_DC_min)
                 .OnDelete(DeleteBehavior.Restrict);

                c.HasOne(c => c.DC_max)
                 .WithMany(dc => dc.Categories_DC_max)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TypeOfLogic>(tol =>
            {
                tol.HasOne(tol => tol.PL_max)
                   .WithMany(p => p.TypeOfLogics);

                tol.HasOne(tol => tol.Category_max)
                   .WithMany(c => c.TypeOfLogics);

                tol.HasOne(tol => tol.SIL_max)
                   .WithMany(s => s.TypeOfLogics);

                tol.HasOne(tol => tol.Architecture_max)
                   .WithMany(a => a.TypeOfLogics);
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
            });

            builder.Entity<Entity>(e =>
            {
                e.HasMany(e => e.States)
                 .WithOne(s => s.Entity);
            });

            builder.Entity<StateTransition>(st =>
            {
                st.HasOne(st => st.CurrentState)
                  .WithMany(cs => cs.StateTransitions_current);

                st.HasOne(st => st.NextState)
                  .WithMany(ns => ns.StateTransitions_next);
            });
        }
    }
}

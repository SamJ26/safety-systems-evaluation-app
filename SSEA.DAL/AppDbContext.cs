using System;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<Producer> Producers { get; set; }
        public DbSet<CCF> CCFs { get; set; }
        public DbSet<DC> DCs { get; set; }
        public DbSet<EvaluationMethod> EvaluationMethods { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        public DbSet<Norm> Norms { get; set; }
        public DbSet<OperationPrinciple> OperationPrinciples { get; set; }
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
        public DbSet<Fr> Frs { get; set; }
        public DbSet<PFHd> PFHds { get; set; }
        public DbSet<Pr> Prs { get; set; }
        public DbSet<Se> Ses { get; set; }
        public DbSet<SFF> SFFs { get; set; }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StateTransition> StateTransitions { get; set; }

        #endregion

        public async Task<int> CommitChangesAsync(int userId = 0)
        {
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.Entity is IExtendedEntityBase && (e.State == EntityState.Added || e.State == EntityState.Modified))
                                       .ToList();

            foreach (var entry in entries)
            {
                // Existing entity was modified
                if (entry.State.Equals(EntityState.Modified))
                {
                    entry.Property("DateTimeUpdated").CurrentValue = DateTime.Now;
                    entry.Property("IdUpdated").CurrentValue = userId;
                }
                // New entity was added
                else
                {
                    entry.Property("DateTimeCreated").CurrentValue = DateTime.Now;
                    entry.Property("IdCreated").CurrentValue = userId;
                }
            }
            return await SaveChangesAsync();
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

            #region Global query filters

            builder.Entity<AccessPoint>().HasQueryFilter(ap => ap.IsRemoved != true);
            builder.Entity<Element>().HasQueryFilter(e => e.IsRemoved != true);
            builder.Entity<Machine>().HasQueryFilter(m => m.IsRemoved != true);
            builder.Entity<SafetyFunction>().HasQueryFilter(sf => sf.IsRemoved != true);
            builder.Entity<Subsystem>().HasQueryFilter(s => s.IsRemoved != true);

            builder.Entity<AccessPointSafetyFunction>().HasQueryFilter(apsf => apsf.IsRemoved != true);
            builder.Entity<ElementSFF>().HasQueryFilter(es => es.IsRemoved != true);
            builder.Entity<MachineNorm>().HasQueryFilter(mn => mn.IsRemoved != true);
            builder.Entity<SafetyFunctionSubsystem>().HasQueryFilter(sfs => sfs.IsRemoved != true);
            builder.Entity<SubsystemCCF>().HasQueryFilter(sc => sc.IsRemoved != true);

            #endregion

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
                    .OnDelete(DeleteBehavior.Restrict);

                apsf.HasOne(apsf => apsf.AccessPoint)
                    .WithMany(ap => ap.AccessPointSafetyFunctions)
                    .HasForeignKey(apsf => apsf.AccessPointId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<SafetyFunctionSubsystem>(sfs =>
            {
                sfs.HasKey(sfs => new { sfs.SafetyFunctionId, sfs.SubsystemId });

                sfs.HasOne(sfs => sfs.Subsystem)
                   .WithMany(s => s.SafetyFunctionSubsystems)
                   .HasForeignKey(sfs => sfs.SubsystemId)
                   .OnDelete(DeleteBehavior.Restrict);

                sfs.HasOne(sfs => sfs.SafetyFunction)
                   .WithMany(sf => sf.SafetyFunctionSubsystems)
                   .HasForeignKey(sfs => sfs.SafetyFunctionId)
                   .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Machine>(m =>
            {
                m.HasOne(m => m.Producer)
                 .WithMany()
                 .HasForeignKey(m => m.ProducerId)
                 .OnDelete(DeleteBehavior.Restrict);

                m.HasMany(m => m.AccessPoints)
                 .WithOne(a => a.Machine)
                 .HasForeignKey(a => a.MachineId)
                 .OnDelete(DeleteBehavior.Restrict);

                m.HasOne(m => m.EvaluationMethod)
                 .WithMany()
                 .HasForeignKey(m => m.EvaluationMethodId)
                 .OnDelete(DeleteBehavior.Restrict);

                m.HasOne(m => m.MachineType)
                 .WithMany()
                 .HasForeignKey(m => m.MachineTypeId)
                 .OnDelete(DeleteBehavior.Restrict);

                m.HasOne(m => m.TypeOfLogic)
                 .WithMany()
                 .HasForeignKey(m => m.TypeOfLogicId)
                 .OnDelete(DeleteBehavior.Restrict);

                m.HasOne(m => m.CurrentState)
                 .WithMany()
                 .HasForeignKey(m => m.CurrentStateId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<AccessPoint>(ap =>
            {
                ap.HasOne(ap => ap.CurrentState)
                  .WithMany()
                  .HasForeignKey(ap => ap.CurrentStateId)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<SafetyFunction>(sf =>
            {
                sf.HasOne(sf => sf.TypeOfFunction)
                  .WithMany()
                  .HasForeignKey(sf => sf.TypeOfFunctionId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.EvaluationMethod)
                  .WithMany()
                  .HasForeignKey(sf => sf.EvaluationMethodId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.RequiredPL)
                  .WithMany()
                  .HasForeignKey(sf => sf.RequiredPLId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.ResultantPL)
                  .WithMany()
                  .HasForeignKey(sf => sf.ResultantPLId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.S)
                  .WithMany()
                  .HasForeignKey(sf => sf.SId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.F)
                  .WithMany()
                  .HasForeignKey(sf => sf.FId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.P)
                  .WithMany()
                  .HasForeignKey(sf => sf.PId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.SILCL)
                  .WithMany()
                  .HasForeignKey(sf => sf.SILCLId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.RequiredSIL)
                  .WithMany()
                  .HasForeignKey(sf => sf.RequiredSILId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.Se)
                  .WithMany()
                  .HasForeignKey(sf => sf.SeId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.Fr)
                  .WithMany()
                  .HasForeignKey(sf => sf.FrId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.Pr)
                  .WithMany()
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.Av)
                  .WithMany()
                  .HasForeignKey(sf => sf.AvId)
                  .OnDelete(DeleteBehavior.Restrict);

                sf.HasOne(sf => sf.CurrentState)
                  .WithMany()
                  .HasForeignKey(sf => sf.CurrentStateId)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Subsystem>(s =>
            {
                s.HasMany(s => s.Elements)
                 .WithOne(e => e.Subsystem)
                 .HasForeignKey(e => e.SubsystemId)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.TypeOfSubsystem)
                 .WithMany()
                 .HasForeignKey(s => s.TypeOfSubsystemId)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.OperationPrinciple)
                 .WithMany()
                 .HasForeignKey(s => s.OperationPrincipleId)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.ResultantMTTFd)
                 .WithMany()
                 .HasForeignKey(s => s.ResultantMTTFdId)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.ResultantDC)
                 .WithMany()
                 .HasForeignKey(s => s.ResultantDCId)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.ResultantPL)
                 .WithMany()
                 .HasForeignKey(s => s.ResultantPLId)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.Architecture)
                 .WithMany()
                 .HasForeignKey(s => s.ArchitectureId)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.ResultantPFHd)
                 .WithMany()
                 .HasForeignKey(s => s.ResultantPFHdId)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.Category)
                 .WithMany()
                 .HasForeignKey(s => s.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(s => s.CurrentState)
                 .WithMany()
                 .HasForeignKey(s => s.CurrentStateId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Element>(e =>
            {
                e.HasOne(e => e.Producer)
                 .WithMany()
                 .HasForeignKey(e => e.ProducerId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.DC)
                 .WithMany()
                 .HasForeignKey(e => e.DCId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.ResultantMTTFd)
                 .WithMany()
                 .HasForeignKey(e => e.ResultantMTTFdId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.CurrentState)
                 .WithMany()
                 .HasForeignKey(e => e.CurrentStateId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<SubsystemCCF>(sc =>
            {
                sc.HasKey(sc => new { sc.SubsystemId, sc.CCFId });

                sc.HasOne(sc => sc.CCF)
                  .WithMany(c => c.SubsystemCCFs)
                  .HasForeignKey(sc => sc.CCFId)
                  .OnDelete(DeleteBehavior.Restrict);

                sc.HasOne(sc => sc.Subsystem)
                  .WithMany(s => s.SubsystemCCFs)
                  .HasForeignKey(sc => sc.SubsystemId)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ElementSFF>(es =>
            {
                es.HasKey(es => new { es.ElementId, es.SFFId });

                es.HasOne(es => es.SFF)
                  .WithMany(s => s.ElementSFFs)
                  .HasForeignKey(es => es.SFFId)
                  .OnDelete(DeleteBehavior.Restrict);

                es.HasOne(es => es.Element)
                  .WithMany(e => e.ElementSFFs)
                  .HasForeignKey(es => es.ElementId)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Architecture>(a =>
            {
                a.HasOne(a => a.MaxPFHd)
                 .WithMany()
                 .HasForeignKey(a => a.MaxPFHdId)
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
                   .WithMany()
                   .HasForeignKey(tol => tol.MaxPLId)
                   .OnDelete(DeleteBehavior.Restrict);

                tol.HasOne(tol => tol.MaxCategory)
                   .WithMany()
                   .HasForeignKey(tol => tol.MaxCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

                tol.HasOne(tol => tol.MaxSIL)
                   .WithMany()
                   .HasForeignKey(tol => tol.MaxSILId)
                   .OnDelete(DeleteBehavior.Restrict);

                tol.HasOne(tol => tol.MaxArchitecture)
                   .WithMany()
                   .HasForeignKey(tol => tol.MaxArchitectureId)
                   .OnDelete(DeleteBehavior.Restrict);

                tol.HasOne(tol => tol.Subsystem)
                   .WithMany()
                   .HasForeignKey(tol => tol.SubsystemId)
                   .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<MachineNorm>(mn =>
            {
               mn.HasKey(mn => new { mn.MachineId, mn.NormId });

               mn.HasOne(mn => mn.Norm)
                 .WithMany(n => n.MachineNorms)
                 .HasForeignKey(mn => mn.NormId)
                 .OnDelete(DeleteBehavior.Restrict);

               mn.HasOne(mn => mn.Machine)
                 .WithMany(m => m.MachineNorms)
                 .HasForeignKey(mn => mn.MachineId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Entity>(e =>
            {
                e.HasMany(e => e.States)
                 .WithOne(s => s.Entity)
                 .HasForeignKey(s => s.EntityId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<StateTransition>(st =>
            {
                st.HasOne(st => st.CurrentState)
                  .WithMany()
                  .HasForeignKey(st => st.CurrentStateId)
                  .OnDelete(DeleteBehavior.Restrict);

                st.HasOne(st => st.NextState)
                  .WithMany()
                  .HasForeignKey(st => st.NextStateId)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            builder.SeedData();
        }
    }
}

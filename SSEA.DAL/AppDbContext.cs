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
using SSEA.DAL.Extensions;

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
            builder.Entity<Role>().ToTable("SY_Role");
            builder.Entity<User>().ToTable("SY_User");

            builder.ConfigureRelationships();

            builder.SeedData();
        }
    }
}

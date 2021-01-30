using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.Auth;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;

namespace SSEA.DAL
{
    public class AppDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<AccessPoint> AccessPoints { get; set; }
        public DbSet<AccessPointSafetyFunction> AccessPointSafetyFunctions { get; set; }
        public DbSet<SafetyFunction> SafetyFunctions { get; set; }
        public DbSet<SafetyFunctionSubsystem> SafetyFunctionSubsystems { get; set; }
        public DbSet<Subsystem> Subsystems { get; set; }
        public DbSet<Element> Elements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User can have many UserClaims
            // User can have many UserLogins
            // User can have many UserTokens
            // Role can have many RoleClaims
            // User can have many Roles, one Role can be associated with many Users (UserRole = join table)

            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<UserClaim>().ToTable("UserClaim");
            builder.Entity<UserRole>().ToTable("UserRole");
            builder.Entity<UserLogin>().ToTable("UserLogin");
            builder.Entity<RoleClaim>().ToTable("RoleClaim");
            builder.Entity<UserToken>().ToTable("UserToken");

            builder.Entity<Machine>().HasOne(m => m.Producer)
                                     .WithMany(p => p.Machines);

            builder.Entity<Machine>().HasMany(m => m.AccessPoints)
                                     .WithOne(a => a.Machine);

            builder.Entity<AccessPointSafetyFunction>().HasKey(apsf => new { apsf.AccessPointId, apsf.SafetyFunctionId });

            builder.Entity<AccessPointSafetyFunction>().HasOne(apsf => apsf.SafetyFunction)
                                                       .WithMany(sf => sf.AccessPointSafetyFunctions)
                                                       .HasForeignKey(apsf => apsf.SafetyFunctionId);

            builder.Entity<AccessPointSafetyFunction>().HasOne(apsf => apsf.AccessPoint)
                                                       .WithMany(ap => ap.AccessPointSafetyFunctions)
                                                       .HasForeignKey(apsf => apsf.AccessPointId);

            builder.Entity<SafetyFunctionSubsystem>().HasKey(sfs => new { sfs.SafetyFunctionId, sfs.SubsystemId });

            builder.Entity<SafetyFunctionSubsystem>().HasOne(sfs => sfs.Subsystem)
                                                     .WithMany(s => s.SafetyFunctionSubsystems)
                                                     .HasForeignKey(sfs => sfs.SubsystemId);

            builder.Entity<SafetyFunctionSubsystem>().HasOne(sfs => sfs.SafetyFunction)
                                                     .WithMany(sf => sf.SafetyFunctionSubsystems)
                                                     .HasForeignKey(sfs => sfs.SafetyFunctionId);

            builder.Entity<Subsystem>().HasMany(s => s.Elements)
                                       .WithOne(e => e.Subsystem);

            builder.Entity<Machine>().HasOne(m => m.EvaluationMethod)
                                     .WithMany(em => em.Machines);

            builder.Entity<Machine>().HasOne(m => m.MachineType)
                                     .WithMany(mt => mt.Machines);

            builder.Entity<Machine>().HasOne(m => m.TypeOfLogic)
                                     .WithMany(t => t.Machines);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.TypeOfFunction)
                                            .WithMany(tof => tof.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.EvaluationMethod)
                                            .WithMany(em => em.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.PLr)
                                            .WithMany(pl => pl.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.PL_result)
                                            .WithMany(pl => pl.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.S)
                                            .WithMany(s => s.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.F)
                                            .WithMany(f => f.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.P)
                                            .WithMany(p => p.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.SILCL)
                                            .WithMany(p => p.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.SIL_result)
                                            .WithMany(p => p.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.Se)
                                            .WithMany(s => s.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.Fr)
                                            .WithMany(f => f.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.Pr)
                                            .WithMany(p => p.SafetyFunctions);

            builder.Entity<SafetyFunction>().HasOne(sf => sf.Av)
                                            .WithMany(a => a.SafetyFunctions);

        }
    }
}

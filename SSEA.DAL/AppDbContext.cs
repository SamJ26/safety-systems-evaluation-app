﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.Auth;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics;
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

            builder.Entity<Subsystem>().HasOne(s => s.TypeOfSubsystem)
                                       .WithMany(t => t.Subsystems);

            builder.Entity<SubsystemCCF>().HasKey(sc => new { sc.SubsystemId, sc.CCF_Id });

            builder.Entity<SubsystemCCF>().HasOne(sc => sc.CCF)
                                          .WithMany(c => c.SubsystemCCFs)
                                          .HasForeignKey(sc => sc.CCF_Id);

            builder.Entity<SubsystemCCF>().HasOne(sc => sc.Subsystem)
                                          .WithMany(s => s.SubsystemCCFs)
                                          .HasForeignKey(sc => sc.SubsystemId);

            builder.Entity<Subsystem>().HasOne(s => s.Category)
                                       .WithMany(c => c.Subsystems);

            builder.Entity<Subsystem>().HasOne(s => s.MTTFd_result)
                                       .WithMany(m => m.Subsystems);

            builder.Entity<Subsystem>().HasOne(s => s.DC_result)
                                       .WithMany(d => d.Subsystems);

            builder.Entity<Subsystem>().HasOne(s => s.PL_result)
                                       .WithMany(p => p.Subsystems);

            builder.Entity<Subsystem>().HasOne(s => s.Architecture)
                                       .WithMany(a => a.Subsystems);

            builder.Entity<Subsystem>().HasOne(s => s.HFT)
                                       .WithMany(h => h.Subsystems);

            builder.Entity<Subsystem>().HasOne(s => s.PFHd_result)
                                       .WithMany(p => p.Subsystems);

            builder.Entity<Subsystem>().HasOne(s => s.CFF)
                                       .WithMany(c => c.Subsystems);

            builder.Entity<Element>().HasOne(e => e.Producer)
                                     .WithMany(p => p.Elements);

            builder.Entity<Element>().HasOne(e => e.Subsystem)
                                     .WithMany(s => s.Elements);

            builder.Entity<Element>().HasOne(e => e.DC)
                                     .WithMany(d => d.Elements);

            builder.Entity<Element>().HasOne(e => e.MTTFd_result)
                                     .WithMany(m => m.Elements);

            builder.Entity<ElementSFF>().HasKey(es => new { es.ElementId, es.SFF_Id });

            builder.Entity<ElementSFF>().HasOne(es => es.SFF)
                                        .WithMany(s => s.ElementSFFs)
                                        .HasForeignKey(es => es.SFF_Id);

            builder.Entity<ElementSFF>().HasOne(es => es.Element)
                                        .WithMany(e => e.ElementSFFs)
                                        .HasForeignKey(es => es.ElementId);

            builder.Entity<Architecture>().HasOne(a => a.SFF_min)
                                          .WithMany(s => s.Architectures);

            builder.Entity<Architecture>().HasOne(a => a.SFF_max)
                                          .WithMany(s => s.Architectures);

            builder.Entity<Architecture>().HasOne(a => a.HFT)
                                          .WithMany(h => h.Architectures);

            builder.Entity<Architecture>().HasOne(a => a.PFHd_max)
                                          .WithMany(p => p.Architectures);

            builder.Entity<Category>().HasOne(c => c.MTTFd_max)
                                      .WithMany(m => m.Categories);

            builder.Entity<Category>().HasOne(c => c.MTTFd_min)
                                      .WithMany(m => m.Categories);

            builder.Entity<Category>().HasOne(c => c.DC_min)
                                      .WithMany(dc => dc.Categories);

            builder.Entity<Category>().HasOne(c => c.DC_max)
                                      .WithMany(dc => dc.Categories);

            builder.Entity<TypeOfLogic>().HasOne(tol => tol.PL_max)
                                         .WithMany(p => p.TypeOfLogics);

            builder.Entity<TypeOfLogic>().HasOne(tol => tol.Category_max)
                                         .WithMany(c => c.TypeOfLogics);

            builder.Entity<TypeOfLogic>().HasOne(tol => tol.SIL_max)
                                         .WithMany(s => s.TypeOfLogics);

            builder.Entity<TypeOfLogic>().HasOne(tol => tol.Architecture_max)
                                         .WithMany(a => a.TypeOfLogics);
        }
    }
}

﻿using CCM.Domain.Entities.Companies;
using CCM.Domain.Entities.Components;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Persons;
using CCM.Domain.Entities.Shops;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Concrete
{
    /// <summary>
    /// Define la estructura de la base de datos de la aplicación.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        #region Tables

        #region Computadoras
        /// <summary>
        /// Tabla de los PC
        /// </summary>
        public DbSet<PC> PC { get; set; }
        /// <summary>
        /// Tabla de los discos duros
        /// </summary>
        public DbSet<HardDrive> HardDrive { get; set; }
        /// <summary>
        /// Tabla de las Motherboards
        /// </summary>
        public DbSet<MotherBoard> MotherBoard { get; set; }
        /// <summary>
        /// Tabla de las memorias RAm
        /// </summary>
        public DbSet<RAM> RAM { get; set; }
        #endregion

        #region Trabajadores, Tienda y Compañia
        /// <summary>
        /// Tabla de trabajadores
        /// </summary>
        public DbSet<Worker> Workers { get; set; }
        /// <summary>
        /// Tabla de Tiendas
        /// </summary>
        public DbSet<Shop> Shops { get; set; }
        /// <summary>
        /// Tabla de la Compañia
        /// </summary>
        public DbSet<Company> Companies { get; set; } 

        #endregion

        #endregion

        #region Constructors
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        public ApplicationContext()
        {
        }

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="connectionString">
        /// Cadena de conexión.
        /// </param>
        public ApplicationContext(string connectionString)
            : base(GetOptions(connectionString))
        {}

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="options">
        /// Opciones del contexto.
        /// </param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)  {}
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Base classes mapping

            modelBuilder.Entity<PC>().ToTable("PC");

            modelBuilder.Entity<HardDrive>().ToTable("HardDrive");

            modelBuilder.Entity<MotherBoard>().ToTable("MotherBoard");

            modelBuilder.Entity<RAM>().ToTable("RAM");

            modelBuilder.Entity<Microprocesor>().ToTable("Microprocesor");

            modelBuilder.Entity<Worker>().ToTable("Workers");

            modelBuilder.Entity<Shop>().ToTable("Shops");

            modelBuilder.Entity<Company>().ToTable("Companies");
            #endregion
        }

        #region Helpers
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }
        #endregion

    }
}

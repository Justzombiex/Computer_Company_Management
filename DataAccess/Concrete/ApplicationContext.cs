
using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Companies;
using CCM.Domain.Entities.Persons;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Orders;
using CCM.Domain.Entities.Persons;
using CCM.Domain.Entities.Shops;
using CCM.DataAccess.FluentConfigurations;
using Microsoft.EntityFrameworkCore;
using CCM.DataAccess.FluentConfigurations;

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
        public DbSet<PC> PCs { get; set; }
        /// <summary>
        /// Tabla de los discos duros
        /// </summary>
        public DbSet<HardDrive> HardDrives { get; set; }
        /// <summary>
        /// Tabla de las Motherboards
        /// </summary>
        public DbSet<MotherBoard> MotherBoards { get; set; }
        /// <summary>
        /// Tabla de las memorias RAm
        /// </summary>
        public DbSet<RAM> RAMs { get; set; }
        /// <summary>
        /// Tabla de los precios
        /// </summary>
        public DbSet<Price> Prices { get; set; }
        #endregion

        #region Trabajadores, Tienda, Compañia y Orden de compra
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
        /// <summary>
        /// Tabla de las Órdenes de compra
        /// </summary>
        public DbSet<BuyOrder> BuyOrders { get; set; }

        #endregion

        #region Clientes
        
        /// <summary>
        /// Tabla de los clientes
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Tabla de ubicación geográfica de una entidad.
        /// </summary>
        public DbSet<PhysicalLocation> PhysicalLocations { get; set; }

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


        #endregion

        /// <summary>
        /// Sobrescribimos la función OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }


        /// <summary>
        /// Sobrescribimos la función OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Base classes mapping

            modelBuilder.Entity<PC>().ToTable("PCs");

            modelBuilder.Entity<HardDrive>().ToTable("HardDrives");

            modelBuilder.Entity<MotherBoard>().ToTable("MotherBoards");

            modelBuilder.Entity<RAM>().ToTable("RAMs");

            modelBuilder.Entity<Microprocesor>().ToTable("Microprocesors");

            modelBuilder.Entity<Price>().ToTable("Prices");

            modelBuilder.Entity<Worker>().ToTable("Workers");

            modelBuilder.Entity<Client>().ToTable("Clients");

            modelBuilder.Entity<PhysicalLocation>().ToTable("PhysicalLocations");

            modelBuilder.Entity<Shop>().ToTable("Shops");

            modelBuilder.Entity<Company>().ToTable("Companies");

            modelBuilder.Entity<BuyOrder>().ToTable("BuyOrders");

            modelBuilder.ApplyConfiguration(new PrivateClientFluentConfiguration());
            
            modelBuilder.ApplyConfiguration(new EnterpriseClientFluentConfiguration());

            #endregion

            modelBuilder.ApplyConfiguration(new EnterpriseClientFluentConfiguration());
            modelBuilder.ApplyConfiguration(new PrivateClientFluentConfiguration());
        }

        #region Helpers
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }
        #endregion

    }
}

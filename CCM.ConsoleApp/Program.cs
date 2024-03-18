using CCM.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCM.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Creando un contexto para interactuar con la Base de datos.
            ApplicationContext appContext = new ApplicationContext("Data Source=CCMDB.sqlite");
            // Verificando si la BD no existe
            if (!appContext.Database.CanConnect())
            {
                // Migrando base de datos. Este paso genera la BD con las tablas configuradas en su migración.
                appContext.Database.Migrate();
            }
        }
    }
}

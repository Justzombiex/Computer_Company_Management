using CCM.DataAccess.Concrete;
using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Components;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Types;
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
          /*
            //Create PC
            HardDrive hardDrive = new HardDrive("HDD", "Seagate", 2 , ConnectionHardDriveType.SATA);
            appContext.Set<HardDrive>().Add(hardDrive);
            appContext.SaveChanges();

            Microprocesor microprocesor = new Microprocesor("Core i3", 2, "Intel", ConnectionType.PGA);
            appContext.Set<Microprocesor>().Add(microprocesor);
            appContext.SaveChanges();

            MotherBoard motherBoard = new MotherBoard("ROG Strix", "ASUS", ConnectionType.PGA);
            appContext.Set<MotherBoard>().Add(motherBoard);
            appContext.SaveChanges();

            RAM rAM = new RAM(16, "Kingston", MemoryType.DDR);
            appContext.Set<RAM>().Add(rAM);
            appContext.SaveChanges();

            Price price = new Price(MoneyType.USD, 6200);
            appContext.Set<Microprocesor>().Add(microprocesor);
            appContext.SaveChanges();

            PC pC = new PC(hardDrive, microprocesor, rAM, motherBoard, price);
            appContext.Set<PC>().Add(pC);
            appContext.SaveChanges();

            */
        }
    }
}

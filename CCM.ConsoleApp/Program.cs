using CCM.DataAccess.Concrete;
using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Components;
using CCM.Domain.Entities.Computers;
using CCM.Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using CCM.GrpcProtos;
using Grpc.Net.Client;

namespace   CCM.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Presione una tecla para conectar");
            Console.ReadKey();

            Console.WriteLine("Creating channel and client");
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5051", new GrpcChannelOptions { HttpHandler = httpHandler });
            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("1. Opciones de Price");
                Console.WriteLine("2. Opciones de HardDrive");
                Console.WriteLine("3. Opciones de RAM");
                Console.WriteLine("4. Opciones de Microprocesor");
                Console.WriteLine("5. Opciones de PC");
                Console.WriteLine("6. Salir");
                Console.WriteLine("Elige una de las opciones");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    #region Price
                    case 1:
                        Console.WriteLine("Has elegido las opciones de Price");
                        var price = new CCM.GrpcProtos.Price.PriceClient(channel);
                        Console.WriteLine("Presiona cualquier tecla para crear un precio");
                        Console.ReadKey();
                        var createPrice = price.CreatePrice(new CreatePriceRequest() { Value = 5, MoneyType = MoneyTypes.Mlc });
                        if (createPrice is null)
                        {
                            Console.WriteLine("Cannot create price");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Creación exitosa.");
                        }

                        Console.WriteLine("Presione una tecla para obtener el precio");
                        Console.ReadKey();
                        var getPrice = price.GetPrice(new GetRequest() { Id = 1 });
                        if (getPrice.Price is null)
                        {
                            Console.WriteLine("Cannot get price");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Obtención exitosa {getPrice.Price.Value} {getPrice.Price.MoneyType.ToString() }");

                        }

                        Console.WriteLine("Presione una tecla para modificar el precio");
                        Console.ReadKey();
                        createPrice.Value = 20;
                        price.UpdatePrice(createPrice);

                        var updatedGetPrice = price.GetPrice(new GetRequest() { Id = createPrice.Id });
                        if (updatedGetPrice is not null && updatedGetPrice.KindCase == NullablePriceDTO.KindOneofCase.Price && updatedGetPrice.Price.Value == 20)
                        {
                            Console.WriteLine($"Modificación exitosa.");
                        }

                        Console.WriteLine("Presione una tecla para eliminar el precio");
                        Console.ReadKey();

                        price.DeletePrice(createPrice);
                        var deletedGetprice = price.GetPrice(new GetRequest() { Id = createPrice.Id });
                        if (deletedGetprice is null || deletedGetprice.KindCase != NullablePriceDTO.KindOneofCase.Price)
                        {
                            Console.WriteLine($"Eliminación exitosa.");
                        }

                        break;
                    #endregion Price
                    #region HardDrive
                    case 2:
                        Console.WriteLine("Has elegido las opciones de disco duro");
                        var harddrive = new CCM.GrpcProtos.HardDrive.HardDriveClient(channel);
                        Console.WriteLine("Presione una tecla para crear un disco duro");
                        Console.ReadKey();
                        var createHardDrive = harddrive.CreateHardDrive(new CreateHardDriveRequest() { Brand = "Seagate", Model = "Simple", Storage = 2, ConnectionHardDrivesType = ConnectionHardDrivesTypes.Sata });
                        if (createHardDrive is null)
                        {
                            Console.WriteLine("Cannot create hardDrive");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Creación exitosa.");
                        }

                        Console.WriteLine("Presione una tecla para obtener el disco duro");
                        Console.ReadKey();
                        var getRam = harddrive.GetHardDrive(new GetRequest() { Id = 1 });
                        if (getRam.Harddrive is null)
                        {
                            Console.WriteLine("Cannot get HardDrive");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Obtención exitosa {getRam.Harddrive.Brand}  {getRam.Harddrive.Model} {getRam.Harddrive.Storage} {getRam.Harddrive.ConnectionHardDrivesType.ToString() }");

                        }



                        Console.WriteLine("Presione una tecla para eliminar el HardDrive");
                        Console.ReadKey();

                        harddrive.DeleteHardDrive(createHardDrive);
                        var deletedGetHardDrive = harddrive.GetHardDrive(new GetRequest() { Id = createHardDrive.Id });
                        if (deletedGetHardDrive is null || deletedGetHardDrive.KindCase != NullableHardDriveDTO.KindOneofCase.Harddrive)
                        {
                            Console.WriteLine($"Eliminación exitosa.");
                        }

                        break;
                        #endregion HardDrive
                        16, "Kingston", MemoryType.DDR
                    #region RAM
                    case 3:
                        Console.WriteLine("Has elegido las opciones de la RAM");
                        var ram = new CCM.GrpcProtos.RAM.RAMClient(channel);
                        Console.WriteLine("Presione una tecla para crear un disco duro");
                        Console.ReadKey();
                        var createRam = ram.CreateRAM(new CreateRAMRequest() { MemorySize = 2 , Brand = "Kingston", MemoryType = MemoryTypes.Ddr});
                        if (createRam is null)
                        {
                            Console.WriteLine("Cannot create hardDrive");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Creación exitosa.");
                        }

                        Console.WriteLine("Presione una tecla para obtener el disco duro");
                        Console.ReadKey();
                        var getRam = harddrive.GetHardDrive(new GetRequest() { Id = 1 });
                        if (getRam.Harddrive is null)
                        {
                            Console.WriteLine("Cannot get HardDrive");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Obtención exitosa {getRam.Harddrive.Brand}  {getRam.Harddrive.Model} {getRam.Harddrive.Storage} {getRam.Harddrive.ConnectionHardDrivesType.ToString() }");

                        }



                        Console.WriteLine("Presione una tecla para eliminar el HardDrive");
                        Console.ReadKey();

                        harddrive.DeleteHardDrive(createHardDrive);
                        var deletedGetResponses = harddrive.GetHardDrive(new GetRequest() { Id = createHardDrive.Id });
                        if (deletedGetHardDrive is null || deletedGetHardDrive.KindCase != NullableHardDriveDTO.KindOneofCase.Harddrive)
                        {
                            Console.WriteLine($"Eliminación exitosa.");
                        }
                        break;
                    #endregion RAM

                    case 4:
                        Console.WriteLine("Has elegido la opción 4");
                        Console.WriteLine("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("Has elegido salir de la aplicación");
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Elige una opcion entre 1 y 5");
                        break;
                }
            }
        

         channel.Dispose();

        }

    }
}
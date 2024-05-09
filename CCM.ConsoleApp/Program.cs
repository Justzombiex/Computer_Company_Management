using CCM.DataAccess.Concrete;
using CCM.Domain.Entities.Common;
using CCM.Domain.Entities.Persons;
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
                Console.WriteLine("5. Opciones de MotherBoard");
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
                        var getharddrive = harddrive.GetHardDrive(new GetRequest() { Id = 1 });
                        if (getharddrive.Harddrive is null)
                        {
                            Console.WriteLine("Cannot get HardDrive");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Obtención exitosa {getharddrive.Harddrive.Brand}  {getharddrive.Harddrive.Model} {getharddrive.Harddrive.Storage} {getharddrive.Harddrive.ConnectionHardDrivesType.ToString() }");

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
                    #region RAM
                    case 3:
                        Console.WriteLine("Has elegido las opciones de la RAM");
                        var ram = new CCM.GrpcProtos.RAM.RAMClient(channel);
                        Console.WriteLine("Presione una tecla para crear una RAM");
                        Console.ReadKey();
                        var createRam = ram.CreateRAM(new CreateRAMRequest() { MemorySize = 2 , Brand = "Kingston", MemoryType = MemoryTypes.Ddr});
                        if (createRam is null)
                        {
                            Console.WriteLine("Cannot create RAM");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Creación exitosa.");
                        }

                        Console.WriteLine("Presione una tecla para obtener el disco duro");
                        Console.ReadKey();
                        var getRam = ram.GetRAM(new GetRequest() { Id = 1 });
                        if (getRam.Ram is null)
                        {
                            Console.WriteLine("Cannot get RAM");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Obtención exitosa {getRam.Ram.MemorySize}  {getRam.Ram.Brand} {getRam.Ram.MemoryType.ToString() }");

                        }



                        Console.WriteLine("Presione una tecla para eliminar la RAM");
                        Console.ReadKey();

                        ram.DeleteRAM(createRam);
                        var deletedGetRAM = ram.GetRAM(new GetRequest() { Id = createRam.Id });
                        if (deletedGetRAM is null || deletedGetRAM.KindCase != NullableRAMDTO.KindOneofCase.Ram)
                        {
                            Console.WriteLine($"Eliminación exitosa.");
                        }
                        break;
                    #endregion RAM
                    #region Microprocesor
                    case 4:
                        Console.WriteLine("Has elegido las opciones del Microprocesador");
                        var microprocesor = new CCM.GrpcProtos.Microprocesor.MicroprocesorClient(channel);
                        Console.WriteLine("Presione una tecla para crear un Microprocesador");
                        Console.ReadKey();
                        var createMicroprocesor = microprocesor.CreateMicroprocesor(new CreateMicroprocesorRequest() { Brand = "Corei3", ProcessorSpeed = 2, Model = "Intel", ConnectionType = ConnectionTypes.Pga});
                        if (createMicroprocesor is null)
                        {
                            Console.WriteLine("Cannot create Microprocesor");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Creación exitosa.");
                        }

                        Console.WriteLine("Presione una tecla para obtener el microprocesador");
                        Console.ReadKey();
                        var getMicroprocesor = microprocesor.GetMicroprocesor(new GetRequest() { Id = 1 });
                        if (getMicroprocesor.Microprocesor is null)
                        {
                            Console.WriteLine("Cannot get Microprocesor");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Obtención exitosa {getMicroprocesor.Microprocesor.Brand}  {getMicroprocesor.Microprocesor.ProcessorSpeed} {getMicroprocesor.Microprocesor.Model} {getMicroprocesor.Microprocesor.ConnectionType.ToString() }");

                        }



                        Console.WriteLine("Presione una tecla para eliminar el microprocesador");
                        Console.ReadKey();

                        microprocesor.DeleteMicroprocesor(createMicroprocesor);
                        var deletedGetMicroprocesor = microprocesor.GetMicroprocesor(new GetRequest() { Id = createMicroprocesor.Id });
                        if (deletedGetMicroprocesor is null || deletedGetMicroprocesor.KindCase != NullableMicroprocesorDTO.KindOneofCase.Microprocesor)
                        {
                            Console.WriteLine($"Eliminación exitosa.");
                        }
                        break;
                    #endregion Microprocesor
                    #region MotherBoard
                    case 5:
                        Console.WriteLine("Has elegido las opciones de Motherboard");
                        var motherboard = new CCM.GrpcProtos.MotherBoard.MotherBoardClient(channel);
                        Console.WriteLine("Presione una tecla para crear un Motherboard");
                        Console.ReadKey();
                        var createMotherboard = motherboard.CreateMotherBoard(new CreateMotherBoardRequest() { Model = "ROG Strix", Brand = "ASUS", ConnectionType = ConnectionTypess.Pgas });
                        if (createMotherboard is null)
                        {
                            Console.WriteLine("Cannot create Motherboard");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Creación exitosa.");
                        }

                        Console.WriteLine("Presione una tecla para obtener la motherboard");
                        Console.ReadKey();
                        var getMotherboard = motherboard.GetMotherBoard(new GetRequest() { Id = 1 });
                        if (getMotherboard.Motherboard is null)
                        {
                            Console.WriteLine("Cannot get Motherboard");
                            channel.Dispose();
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Obtención exitosa {getMotherboard.Motherboard.Brand}  {getMotherboard.Motherboard.Model} {getMotherboard.Motherboard.ConnectionType.ToString() }");

                        }



                        Console.WriteLine("Presione una tecla para eliminar la motherboard");
                        Console.ReadKey();

                        motherboard.DeleteMotherBoard(createMotherboard);
                        var deletedGetMotherboard = motherboard.GetMotherBoard(new GetRequest() { Id = createMotherboard.Id });
                        if (deletedGetMotherboard is null || deletedGetMotherboard.KindCase != NullableMotherBoardDTO.KindOneofCase.Motherboard)
                        {
                            Console.WriteLine($"Eliminación exitosa.");
                        }
                        break;

                    #endregion MotherBoard 
                    case 6:
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
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

            var client = new CCM.GrpcProtos.Price.PriceClient(channel);

            Console.WriteLine("Presione una tecla para crear un precio");
            Console.ReadKey();
            var createResponse = client.CreatePrice(new CreatePriceRequest() { Value = 5, MoneyType = MoneyTypes.Mlc });
            if (createResponse is null)
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
            var getResponse = client.GetPrice(new GetRequest() { Id = 1 });
            if (getResponse.Price is null)
            {
                Console.WriteLine("Cannot get price");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa {getResponse.Price.Value} {getResponse.Price.MoneyType.ToString() }");

            }

            Console.WriteLine("Presione una tecla para modificar el precio");
            Console.ReadKey();
            createResponse.Value = 20;
            client.UpdatePrice(createResponse);

            var updatedGetResponse = client.GetPrice(new GetRequest() { Id = createResponse.Id });
            if (updatedGetResponse is not null && updatedGetResponse.KindCase == NullablePriceDTO.KindOneofCase.Price && updatedGetResponse.Price.Value == 20)
            {
                Console.WriteLine($"Modificación exitosa.");
            }

            Console.WriteLine("Presione una tecla para eliminar el precio");
            Console.ReadKey();

            client.DeletePrice(createResponse);
            var deletedGetResponse = client.GetPrice(new GetRequest() { Id = createResponse.Id });
            if (deletedGetResponse is null || deletedGetResponse.KindCase != NullablePriceDTO.KindOneofCase.Price)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }

            var clients = new CCM.GrpcProtos.HardDrive.HardDriveClient(channel);

            Console.WriteLine("Presione una tecla para crear un disco duro");
            Console.ReadKey();
            var createResponses = clients.CreateHardDrive(new CreateHardDriveRequest() { Brand = "Seagate", Model = "Sinple", Storage = 2, ConnectionHardDrivesType = ConnectionHardDrivesTypes.Sata});
            if (createResponses is null)
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
            var getResponses = clients.GetHardDrive(new GetRequest() { Id = 1 });
            if (getResponses.Harddrive is null)
            {
                Console.WriteLine("Cannot get HardDrive");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa {getResponses.Harddrive.Brand}  {getResponses.Harddrive.Model} {getResponses.Harddrive.Storage} {getResponses.Harddrive.ConnectionHardDrivesType.ToString() }");

            }

 

            Console.WriteLine("Presione una tecla para eliminar el HardDrive");
            Console.ReadKey();

            clients.DeleteHardDrive(createResponses);
            var deletedGetResponses = clients.GetHardDrive(new GetRequest() { Id = createResponses.Id });
            if (deletedGetResponses is null || deletedGetResponses.KindCase != NullableHardDriveDTO.KindOneofCase.Harddrive)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }

            channel.Dispose();

        }

    }
}
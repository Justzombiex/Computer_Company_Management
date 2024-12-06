using CCM.DataAccess.Abstract.Components;
using CCM.Domain.Entities.Persons;
using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Repositories
{
    public partial class ApplicationRepository : IHardDriveRepository
    {
        public HardDrive Create(string model, string brand, double storage, ConnectionHardDriveType connectionHardDriveType)
        {
            Console.WriteLine(connectionHardDriveType);
            HardDrive hardDrive = new HardDrive(model, brand, storage, connectionHardDriveType);
            _context.Add(hardDrive);
            return hardDrive;
        }

        public void Delete(HardDrive hardDrive)
        {
            _context.Remove(hardDrive);
        }

        HardDrive? IHardDriveRepository.Get(int id)
        {
            return _context.Set<HardDrive>().Find(id);
        }
    }
}

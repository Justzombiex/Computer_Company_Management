using CCM.DataAccess.Abstract.Components;
using CCM.Domain.Entities.Components;
using CCM.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.DataAccess.Repositories
{
    public partial class ApplicationRepository : IMotherBoardRepository
    {
        public MotherBoard Create(string model, string brand, ConnectionType connectionType)
        {
            MotherBoard motherBoard = new MotherBoard(model, brand, connectionType);
            _context.Add(motherBoard);
            return motherBoard;
            
        }

        public void Delete(MotherBoard motherBoard)
        {
            _context.Remove(motherBoard);
        }
        public void Update(MotherBoard motherBoard)
        {
            _context.Update(motherBoard);
        }
        MotherBoard? IMotherBoardRepository.Get(int id)
        {
            return _context.Set<MotherBoard>().Find(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Domain.Entities.Types
{
    /// <summary>
    /// Tipos de conexión del disco duro
    /// </summary>
    public enum ConnectionHardDriveType
    {
        /// <summary>
        /// Integrated Drive Electronics
        /// </summary>
        IDE,
        /// <summary>
        /// Serial Advanced Technology Attachment
        /// </summary>
        SATA,
        /// <summary>
        /// Serial Advanced Technology Attachment 2
        /// </summary>
        SATA2,
        /// <summary>
        /// Serial Advanced Technology Attachment 3
        /// </summary>
        SATA3
    }
}

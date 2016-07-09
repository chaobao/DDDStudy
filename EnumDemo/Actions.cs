using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    [Flags]
    enum Actions
    {
        None = 0,
        Read = 0x0001,
        Write = 0x0002,
        ReadWrite = Actions.Read | Actions.Write,
        Delete = 0x0004,
        Query = 0x0008,
        Sync = 0x0010
    }
}

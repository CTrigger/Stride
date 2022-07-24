using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enum
{
    public enum ProcessStatus
    {
        Failed = 0,
        Success = 1,
        NotFound = 10,
        Updated = 20,
        Deleted = 30,
        Exception = 100,
    }
}

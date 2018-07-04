using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public interface IDataManager
    {
        void Save(Manager manager);
        void Load(out Manager manager);
    }
}

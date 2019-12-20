using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxManager.DO.Interfaces
{
    public interface IGetAll<T>
    {
        List<T> GetAll(int id);
    }
}

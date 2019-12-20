using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxManager.DO.Interfaces
{
    public interface ICRUD<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int entityId);
    }
}

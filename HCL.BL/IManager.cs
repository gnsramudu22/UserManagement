using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCL.BL
{
    public interface IManager<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        bool Save(T newObj);
        bool Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogicLayer.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetListDTO();
        T FindDTO(int? id);
        void CreateDTO(T item);
        void UpdateDTO(T item);
        void DeleteDTO(int? id);
        void AddListPeoples(IEnumerable<T> item);
    }
}

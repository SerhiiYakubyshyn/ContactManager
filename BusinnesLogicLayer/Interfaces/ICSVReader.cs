using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogicLayer.Interfaces
{
    public interface ICSVReader<T>
    {
        IEnumerable<T> Parser(Stream stream);
    }
}

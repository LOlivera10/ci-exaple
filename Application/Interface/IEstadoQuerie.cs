using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IEstadoQuerie
    {
        public object Find(int estadoOption);
    }
}

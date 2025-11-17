using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD4_Ejemplo1.Backend.Modelo;

namespace UD4_Ejemplo1.Backend.Servicios
{
    public interface IArticuloRepository : IGenericRepository<Articulo>
    {

      /*  Task<int> GetLastIdAsync();

        Task<bool> IsNumserieUniqueAsync(string numserie);

        IReadOnlyList<string> GetEstados()
      */
    }
}

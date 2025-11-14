using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD4_Ejemplo1.Backend.Modelo;

namespace UD4_Ejemplo1.Backend.Servicios
{
    public class TipoArticuloRepository : GenericRepository<Tipoarticulo>, ITipoArticuloRepository
    {
        public TipoArticuloRepository(DiinventarioexamenContext context, ILogger<GenericRepository<Tipoarticulo>> logger)
            : base(context, logger)
        {
        }
    }
}

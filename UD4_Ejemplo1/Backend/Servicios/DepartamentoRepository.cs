using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD4_Ejemplo1.Backend.Modelo;
using UD4_Ejemplo1.Backend.Servicios;

namespace UD4_Ejemplo1.Backend.Servicios
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(DiinventarioexamenContext context, ILogger<GenericRepository<Departamento>> logger)
            : base(context, logger)
        {
        }
    }
}
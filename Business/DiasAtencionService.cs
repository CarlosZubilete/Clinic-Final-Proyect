using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;
using Entities;

namespace Business
{
  public class DiasAtencionService
  {
    public DiasAtencionService() { }
    public DataTable GetDaysAvailable()
    {
      DaoDiasAtencion daoDiasAtencion = new DaoDiasAtencion();
      return daoDiasAtencion.GetDiasAtencion(); // Name of table
    }

  }
}

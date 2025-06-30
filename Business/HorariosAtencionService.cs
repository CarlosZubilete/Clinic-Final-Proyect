using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;

namespace Business
{
  public class HorariosAtencionService
  {
    public HorariosAtencionService() { }
    public DataTable GetSheduleDoctor()
    {
      DaoHorariosAtencion daoHorariosAtencion = new DaoHorariosAtencion();
      return daoHorariosAtencion.GetHoriosAtencion();

    }
  }
}

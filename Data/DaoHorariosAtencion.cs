using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Data
{
  public class DaoHorariosAtencion
  {
    public DaoHorariosAtencion() { }
    public DataTable GetHoriosAtencion()
    {
      DataAccess dataAccess = new DataAccess();
      return dataAccess.GetDataTable("HorariosAtencion", "SELECT * FROM HorariosAtencion");
    }
  }
}

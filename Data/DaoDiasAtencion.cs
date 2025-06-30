using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data
{
  public class DaoDiasAtencion
  {
    public DaoDiasAtencion() { }
    public DataTable GetDiasAtencion()
    {
      DataAccess dataAccess = new DataAccess();
      return dataAccess.GetDataTable("DiasAtencion", $"SELECT * FROM DiasAtencion");
    }

  }
}

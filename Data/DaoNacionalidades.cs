using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data
{
  public class DaoNacionalidades
  {
    public DaoNacionalidades() { }

    public DataTable GetNacionalidades()
    {
      DataAccess _dataAccess = new DataAccess();
      return _dataAccess.GetDataTable("Nacionalidades", "SELECT * FROM Nacionalidades");
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data
{
  public class DaoProvincia
  {
    public DaoProvincia() { }
    public DataTable GetAllProvincies()
    {
      DataAccess _dataAccess = new DataAccess();
      return _dataAccess.GetDataTable("Provincias", "SELECT * FROM Provincias ");
    }
  }
}

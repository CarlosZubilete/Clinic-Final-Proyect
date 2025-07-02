using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data
{
  public class DaoFecha
  {
    public DaoFecha() { }
    public DataTable GetDayName(string date)
    {
      DataAccess dataAccess = new DataAccess();
      return dataAccess.GetDataTable($"SELECT DATEPART(DAY, '{date}') AS 'NumberDay', DATENAME(WEEKDAY, '{date}') AS 'NameDay'");
    }

  }
}

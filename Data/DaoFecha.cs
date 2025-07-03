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
      return dataAccess.GetDataTable($"SELECT DATEPART(WEEKDAY, '{date}') AS 'NumberDay', DATENAME(WEEKDAY, '{date}') AS 'NameDay'");
    }

    public DataTable GetMonthName(string date)
    {
      DataAccess dataAccess = new DataAccess();
      return dataAccess.GetDataTable($"SELECT DATEPART(MONTH, '{date}') AS 'NumberMonth',DATENAME(MONTH, '{date}') AS 'NameMonth'");
    }
  }
}

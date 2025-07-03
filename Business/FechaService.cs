using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;

namespace Business
{
  public class FechaService
  {
    public FechaService() { }
    public DataTable GetDayName(string date)
    {
      //string date = $"{year}-{month}-{day}";
      DaoFecha daoFecha = new DaoFecha();
      return daoFecha.GetDayName(date);
    }

    public DataTable GetMonthName(string date )
    {
      //string date = $"{year}-{month}-{day}";
      DaoFecha daoFecha = new DaoFecha();
      return daoFecha.GetMonthName(date);
    }
  }
}
// Todo: maye we can get a name of date : 1997-May-Thursday.  
// Todo: maye we can get a number of date : 1997-05-5
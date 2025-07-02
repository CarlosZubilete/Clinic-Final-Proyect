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
    public DataTable GetDayName(string day, string month, string year)
    {
      string date = $"{year}-{month}-{day}";
      DaoFecha daoFecha = new DaoFecha();
      return daoFecha.GetDayName(date);
    }

  }
}

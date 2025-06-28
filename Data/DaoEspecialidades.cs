using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Data
{
  public class DaoEspecialidades
  {
    public DaoEspecialidades() { }
    public DataTable GetEspecialidades()
    {
      DataAccess _dataAccess = new DataAccess();
      return _dataAccess.GetDataTable("Especialidades", $"SELECT * FROM Especialidades");
    }
  }
}

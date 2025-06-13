using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data
{
  public class DaoLocalidades
  {
    public DaoLocalidades() { }
    public DataTable GetLocalidades( int idProvincia)
    {
      DataAccess _dataAccess = new DataAccess();
      return _dataAccess.GetDataTable("Loccalidades", $"SELECT * FROM Localidades Where Id_Provincia = {idProvincia}");
    }

  }
}

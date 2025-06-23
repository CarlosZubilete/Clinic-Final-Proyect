using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data
{
  public class DaoMedico
  {
    public DaoMedico() { }

    public DataTable GetSpeciality()
    {
      DataAccess dataAccess = new DataAccess();
      return dataAccess.GetDataTable("Especialidades", "Select * from Especialidades");
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;


namespace Business
{
  public class LocalidadService
  {
    public LocalidadService() { }
    public DataTable GetLocalidades(int idProvincia)
    {
      DaoLocalidades dao = new DaoLocalidades();
      return dao.GetLocalidades(idProvincia);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;


namespace Business
{
  public class NacionalidadService
  {
    public NacionalidadService() { }
    public DataTable GetNacionalidades()
    {
      DaoNacionalidades dao = new DaoNacionalidades();
      return dao.GetNacionalidades();
    }
  }
}

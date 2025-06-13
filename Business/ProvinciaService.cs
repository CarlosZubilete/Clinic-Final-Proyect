using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;

namespace Business
{
  public class ProvinciaService
  {
    public ProvinciaService() { }
    public DataTable GetAllProvincies()
    {
      DaoProvincia dao = new DaoProvincia();
      return dao.GetAllProvincies();
    }
  }
}

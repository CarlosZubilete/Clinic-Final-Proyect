using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;
using Entities;

namespace Business
{
  public class MedicoService
  {
    public MedicoService() { }
    public DataTable GetSpeciality()
    {
      DaoMedico daoMedico = new DaoMedico();
      return daoMedico.GetSpeciality();
    }
  }
}

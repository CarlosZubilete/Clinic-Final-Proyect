﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;

namespace Business
{
  public class EspecialidadService
  {
    public EspecialidadService() { }

    public DataTable GetSpecialities()
    {
      DaoEspecialidades daoEspecialidades = new DaoEspecialidades();
      return daoEspecialidades.GetEspecialidades(); // Name of table.
    }
  }
}

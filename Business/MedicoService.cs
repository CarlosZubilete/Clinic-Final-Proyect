﻿using System;
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
    public Boolean AddMedico(ref Medico medico)
    {
      int cantRows;

      DaoMedico daoMedico = new DaoMedico();

      if (daoMedico.IsLegajoDuplicate(medico.Legajo))
      {
        return false;
      }

      cantRows = daoMedico.AddMedico(medico);

      if (cantRows == 1)
        return true;
      else
        return false;
    }
    public Boolean ExistsLegajo(String legajo)
    {
      DaoMedico daoMedico = new DaoMedico();
      return daoMedico.IsLegajoDuplicate(legajo);
    }
    public DataTable GetMedicoByLegajo(String legajo)
    {
      DaoMedico daoMedico = new DaoMedico();
      return daoMedico.GetMedicoByLegajo(legajo);
    }
    public DataTable GetAllDoctorsSpecialities(int Id_Specialidad)
    {
      DaoMedico daoMedico = new DaoMedico();
      return daoMedico.GetAllDoctorsSpecialities(Id_Specialidad);
    }
    public DataTable GetDaysAvailableByLegajo(string lejago)
    {
      DaoMedico daoMedico = new DaoMedico();
      return daoMedico.GetDaysAvailableByLegajo(lejago);
    }
    public DataTable GetScheduleDoctorByLegajo(string lejago)
    {
      DaoMedico daoMedico = new DaoMedico();
      return daoMedico.GetScheduleDoctorByLegajo(lejago);
    }
  }
}

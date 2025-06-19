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
  public class PersonaService
  {
    public PersonaService() { }

    public DataTable GetPersonByDNI(string dni)
    {
      
      DaoPersona daoPersona = new DaoPersona();
      return daoPersona.GetPersonByDNI(dni);  
    }
    public bool AddPersona(ref Persona persona)
    {
      int cantRows;

      DaoPersona daoPersona = new DaoPersona();

      if (daoPersona.IsPersonaDuplicate(persona))
      {
        return false;
      }

      cantRows = daoPersona.AddPersona(persona);

      if (cantRows == 1)
        return true;
      else
        return false;
    }
  }
}

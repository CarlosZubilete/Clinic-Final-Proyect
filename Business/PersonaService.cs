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

    public Boolean ExistsDNI(String DNI)
    {
      DaoPersona daoPersona = new DaoPersona();
      return daoPersona.IsPersonaDuplicate(DNI);
    }
    public DataTable GetPersonByDNI(string dni)
    {
      DaoPersona daoPersona = new DaoPersona();
      return daoPersona.GetPersonByDNI(dni);
    }
    public Boolean AddPersona(ref Persona persona)
    {
      int cantRows;

      DaoPersona daoPersona = new DaoPersona();

      if (daoPersona.IsPersonaDuplicate(persona.DNI))
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

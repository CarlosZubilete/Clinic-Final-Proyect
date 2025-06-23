using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class Medico:Persona
  {
    private int legajo;
    private int speciality;
    public Medico() { }
    public int Legajo
    {
      get { return legajo; }
      set { legajo = value; }
    }
    public int Speciality
    {
      get { return speciality; }
      set { speciality = value; }
    }
  }
}

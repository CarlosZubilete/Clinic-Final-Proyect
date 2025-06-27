using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class Medico:Persona
  {
    private string _legajo;
    private int _speciality;
    private int _dias;
    private int _horas;
    public Medico() { }
    public string Legajo
    {
      get { return _legajo; }
      set { _legajo = value; }
    }
    public int Speciality
    {
      get { return _speciality; }
      set { _speciality = value; }
    }
    public int Dias
    {
      get { return _dias; }
      set { _dias = value; }
    }
    public int Horas
    {
      get { return _horas; }
      set { _horas = value; }
    }
  }
}

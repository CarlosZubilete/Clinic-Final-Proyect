using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class Persona
  {
    private string _DNI;
    private string _name;
    private string _lastName;
    private char _sexo;
    private Fecha _fechaNacimiento; // Composition
    private int _idNacionalidad;
    private int _idProvincia;
    private int _idLocalidad;
    private string _address;
    private string _email;
    private string _phone;

    public string DNI
    {
      get { return _DNI; }
      set { _DNI = value; }
    }
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }
    public string LastName
    {
      get { return _lastName; }
      set { _lastName = value; }
    }
    public char Sexo
    {
      get { return _sexo; }
      set { _sexo = value; }
    }
    public Fecha FechaNacimiento
    {
      get { return _fechaNacimiento; }
      set { _fechaNacimiento = value; }
    }
    public int IdNacionalidad
    {
      get { return _idNacionalidad; }
      set { _idNacionalidad = value; }
    }

    public int IdProvincia
    {
      get { return _idProvincia; }
      set { _idProvincia = value; }
    }

    public int IdLocalidad
    {
      get { return _idLocalidad; }
      set { _idLocalidad = value; }
    }
    public string Addres
    {
      get { return _address; }
      set { _address = value; }
    }
    public string Email
    {
      get { return _email; }
      set { _email = value; }
    }

    public string Phone
    {
      get { return _phone; }
      set { _phone = value; }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  class Provincia
  {
    private int _id;
    private String _name;
    public Provincia() { }
    public int Id
    {
      get { return _id; }
      set { _id = value; }
    }
    public String Name
    {
      get { return _name; }
      set { _name = value; }
    }
  }
}

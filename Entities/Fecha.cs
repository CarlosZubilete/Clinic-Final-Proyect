using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class Fecha
  {
    private int _dia;
    private int _mes;
    private int _anio;
    private int[] _diasMeses = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    public Fecha()
    {
      // FechaDefault();
    }
    public Fecha(int dia, int mes, int anio)
    {
      _dia = dia;
      _mes = mes;
      _anio = anio;
    }
    public int Day
    {
      get { return _dia; }
      set
      {
        if (value > 0 && value <= 31)
        {
          _dia = value; 
        }
      }
    }
    public int Month
    {
      get { return _mes; }
      set
      {
        if (value > 0 && value <= 12)
        {
          _mes = value; 
        }
      }
    }
    public int Year
    {
      get { return _anio;  }
      set
      {
        //if (value >= 1950  && value <= 2025)
        //{
        //}
          _mes = value;
      }
    }
    public bool FechaValida()
    {
      if (!VerificationYear(_anio)) return false;
      if (!VerificationMonth(_mes)) return false;
      return VerificationDay(_dia);
    }
    public bool VerificationDay(int dia)
    {
      if (_mes < 1 || _mes > 12) return false;
      if (dia > 0 && dia <= _diasMeses[_mes - 1])
      {
        _dia = dia;
        return true;
      }
      return false;
    }
    public bool VerificationMonth(int mes)
    {
      if (mes > 0 && mes <= 12)
      {
        _mes = mes;
        return true;
      }
      return false;
    }
    public bool VerificationYear(int anio)
    {
      if (anio >= 1900 && anio <= 2025)
      {
        _anio = anio;
        UpdateBisiesto();
        return true;
      }
      return false;
    }
    private void FechaDefault()
    {
      _dia = 1;
      _mes = 1;
      _anio = 2020;
    }
    private void UpdateBisiesto()
    {
      _diasMeses[1] = (IsBisiesto(_anio)) ? 29 : 28;
    }

    private bool IsBisiesto(int anio)
    {
      return (anio % 400 == 0 || (anio % 4 == 0 && anio % 100 != 0));
    }
  }
}


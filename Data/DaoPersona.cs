using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace Data
{
  public class DaoPersona
  {
    
    private DataAccess _dataAccess = new DataAccess();
    public DaoPersona() { }
    public int AddPersona(Persona persona)
    {
      SqlCommand command = new SqlCommand();
      this.BuildAddPersonaParameter(ref command, persona);
      return _dataAccess.ExecuteStoredProcedure(command, "spAgregarPersona");
    }
    public DataTable GetPersonByDNI (string dni)
    {
      String query = $"SELECT * FROM Personas WHERE DNI = '{dni}'";
      return _dataAccess.GetDataTable("Personas", query);
    }
    public Boolean IsPersonaDuplicate(Persona persona)
    {
      String query = $"SELECT * FROM Personas WHERE DNI = '{persona.DNI}'";
      return _dataAccess.RecordExists(query);
    }
    private void BuildAddPersonaParameter(ref SqlCommand command , Persona persona)
    {
      SqlParameter parameter;
      // DNI: 
      parameter = command.Parameters.Add("@DNI", SqlDbType.VarChar, 8);
      parameter.Value = persona.DNI;
      // NAME:
      parameter = command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50);
      parameter.Value = persona.Name;
      // LASTNAME:
      parameter = command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50);
      parameter.Value = persona.LastName;
      // SEXO:
      parameter = command.Parameters.Add("@Sexo", SqlDbType.VarChar, 1);
      parameter.Value = persona.Sexo;
      // FECHANACIMIENTO:
      parameter = command.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
      parameter.Value = persona.FechaNacimiento.ToDateTime();
      // NACIONALITY
      parameter = command.Parameters.Add("@Id_Nacionalidad", SqlDbType.Int);
      parameter.Value = persona.IdNacionalidad;
      // PROVINCE
      parameter = command.Parameters.Add("@Id_Provincia", SqlDbType.Int);
      parameter.Value = persona.IdProvincia;
      // LOCALITY
      parameter = command.Parameters.Add("@Id_Localidad", SqlDbType.Int);
      parameter.Value = persona.IdLocalidad;
      // ADDRESS
      parameter = command.Parameters.Add("@Direccion", SqlDbType.VarChar, 100);
      parameter.Value = persona.Addres;
      // EMIIL
      parameter = command.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 100);
      parameter.Value = persona.Email;
      // PHONE
      parameter = command.Parameters.Add("@Telefono", SqlDbType.VarChar, 20);
      parameter.Value = persona.Phone;
    }

  }
}

/*
CREATE PROCEDURE [dbo].[spAgregarPersona](
    @DNI VARCHAR(8),
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Sexo CHAR(1),
    @FechaNacimiento DATE,
    @Id_Nacionalidad INT,
    @Id_Provincia INT,
    @Id_Localidad INT,
    @Direccion VARCHAR(100) = NULL,
    @CorreoElectronico VARCHAR(100) = NULL,
    @Telefono VARCHAR(20) = NULL)
AS
  INSERT INTO Personas (
      DNI, Nombre, Apellido, Sexo, FechaNacimiento,
      Id_Nacionalidad, Id_Provincia, Id_Localidad,
      Direccion, CorreoElectronico, Telefono
  )
  VALUES (
      @DNI, @Nombre, @Apellido, @Sexo, @FechaNacimiento,
      @Id_Nacionalidad, @Id_Provincia, @Id_Localidad,
      @Direccion, @CorreoElectronico, @Telefono
  )
  RETURN
*/
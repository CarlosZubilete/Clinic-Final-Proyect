using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entities;

namespace Data
{
  public class DaoMedico
  {
    public DaoMedico() { }

    public Boolean IsLegajoDuplicate(String legajo)
    {
      DataAccess dataAccess = new DataAccess();
      String query = $"SELECT * FROM Medicos WHERE LegajoMedico = '{legajo}'";
      return dataAccess.RecordExists(query);
    }
    public DataTable GetMedicoByLegajo(String legajo)
    {
      DataAccess dataAccess = new DataAccess();
      String query = $"SELECT * FROM Medicos WHERE LegajoMedico = '{legajo}'";
      return dataAccess.GetDataTable("Medicos", query);
    }
    public DataTable GetAllDoctorsSpecialities(int Id_Especialidad)
    {
      DataAccess dataAccess = new DataAccess();
      String query = $"SELECT P.Nombre + ' ' + P.Apellido AS 'NOMBRE COMPLETO:', M.LegajoMedico FROM Personas P INNER JOIN Medicos M ON P.DNI = M.DNI WHERE M.Id_Especialidad = {Id_Especialidad}";
      return dataAccess.GetDataTable("Medicos", query);
    }
    public DataTable GetDaysAvailableByLegajo(string legajo)
    {
      DataAccess dataAccess = new DataAccess();
      return dataAccess.GetDataTable("Medicos", $"SELECT Medicos.Id_DiasAtencion,Dias.Nombre, Dias.Id_Dia  FROM Medicos JOIN [DiasAtencion.Dias] ON Medicos.Id_DiasAtencion = [DiasAtencion.Dias].Id_DiaAtencion JOIN Dias ON [DiasAtencion.Dias].Id_Dia = Dias.Id_Dia WHERE Medicos.LegajoMedico = '{legajo}'");
    }
    public DataTable GetScheduleDoctorByLegajo(string legajo)
    {
      DataAccess dataAccess = new DataAccess();
      return dataAccess.GetDataTable("Medicos", $"SELECT Horas.Id_Hora, Horas.HoraInicio 'Horario' FROM Medicos JOIN[HorariosAtencion.Horas] ON Medicos.Id_HorariosAtencion = [HorariosAtencion.Horas].Id_HorarioAtencion JOIN Horas ON[HorariosAtencion.Horas].Id_Hora = Horas.Id_Hora WHERE Medicos.LegajoMedico = '{legajo}'");
    }
    public int AddMedico(Medico medico)
    {
      DataAccess dataAccess = new DataAccess();
      SqlCommand command = new SqlCommand();
      this.BuildAddMedicoParameter(ref command, medico);
      return dataAccess.ExecuteStoredProcedure(command, "spAgregarMedico");
    }
    private void BuildAddMedicoParameter(ref SqlCommand command, Medico medico)
    {
      SqlParameter parameter;
      // LEGAJO:
      parameter = command.Parameters.Add("@LegajoMedico", SqlDbType.VarChar, 5);
      parameter.Value = medico.Legajo;
      // DNI: 
      parameter = command.Parameters.Add("@DNI", SqlDbType.Char, 8);
      parameter.Value = medico.DNI;
      // ESPECIALIDAD: 
      parameter = command.Parameters.Add("@Id_Especialidad", SqlDbType.Int);
      parameter.Value = medico.Speciality;
      // HORAS ATENCION: 
      parameter = command.Parameters.Add("@Id_HorariosAtencion", SqlDbType.Int);
      parameter.Value = medico.Horas;
      // DIAS ATENCION
      parameter = command.Parameters.Add("@Id_DiaSAtencion", SqlDbType.Int);
      parameter.Value = medico.Dias;
    }
  }
}
/*

CREATE PROCEDURE [dbo].[spAgregarMedico](
    @LegajoMedico varchar(5) ,
	  @DNI char(8),
    @Id_Especialidad INT,
    @Id_HorariosAtencion INT,
    @Id_DiaSAtencion INT
)
AS
    INSERT INTO Medicos (
        LegajoMedico,
		DNI,
        Id_Especialidad,
        Id_DiasAtencion,
        Id_HorariosAtencion
    )
    VALUES (
        @LegajoMedico,
		@DNI,
        @Id_Especialidad,
        @Id_DiasAtencion,
        @Id_HorariosAtencion
    );
  RETURN 

*/
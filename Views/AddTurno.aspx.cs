using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entities;
using Business;

namespace Views
{
  public partial class AddTurno : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        Load_Specialities();
      }
    }
    protected void btnLookup_Click(object sender, EventArgs e)
    {
      string dni = txtDNI.Text.ToString().Trim();
      PersonaService personaService = new PersonaService();
      DataTable dataPaciente = personaService.GetPersonByDNI(dni);

      if (dataPaciente.Rows.Count > 0 || dataPaciente != null)
      {
        lblFullName.Text = dataPaciente.Rows[0]["Nombre"].ToString() + " " + dataPaciente.Rows[0]["Apellido"].ToString();
      }
      else
      {
        lblFullName.Text = "Canot find data";
      }
    }
    
    private void Load_Specialities()
    {
      EspecialidadService especialidadService = new EspecialidadService();
      DataTable source = especialidadService.GetSpecialities();
      this.BindDropDownList(ddlSpecialities, source, "Nombre", "Id_Especialidad");
    }
    protected void ddlSpecialities_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedId = Convert.ToInt32(ddlSpecialities.SelectedValue);

      if (selectedId != 0)// don't must be '>' cero
      {
        Load_Specialities_Doctors(selectedId);
      }
      else
      {
        ddlSpecialities.Items.Clear();
        ddlSpecialities.Items.Insert(0, new ListItem(" -- Select --", "0"));
        ddlSpecialities.Text = string.Empty;
      }
    }
    private void Load_Specialities_Doctors(int Id_Speciality)
    {
      MedicoService medicoService = new MedicoService();
      DataTable source = medicoService.GetAllDoctorsSpecialities(Id_Speciality);
      this.BindDropDownList(ddlSpecialityDoctors, source, "NOMBRE COMPLETO:", "LegajoMedico");
    }
    protected void ddlSpecialityDoctors_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedSpecialityDoctor = Convert.ToInt32(ddlSpecialityDoctors.SelectedValue);

      if (selectedSpecialityDoctor != 0)
      {
        Load_DaysAvailable(ddlSpecialityDoctors.SelectedValue);
        Load_ScheduleDoctors(ddlSpecialityDoctors.SelectedValue);

        // lblShow.Text += $"Dia: {ddlDaysAvailable.SelectedValue}";
      }
      else
      {
        ddlSpecialityDoctors.Items.Clear();
        ddlSpecialityDoctors.Items.Insert(0, new ListItem(" -- Select --", "0"));
        ddlSpecialityDoctors.Text = string.Empty;
      }
    }
    protected void ddlDaysAvailable_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedDayDoctor = Convert.ToInt32(ddlDaysAvailable.SelectedValue);

      if (selectedDayDoctor > 0)
      {
        lblShow.Text = $"Especialidad seleccionada: {ddlSpecialities.SelectedItem.Text} <br/>";
        lblShow.Text += $"Legajo Doctor: {ddlSpecialityDoctors.SelectedItem.Text} <br/>";
        lblShow.Text += $"Id_Dia = {selectedDayDoctor}";
      }
      else
      {
        lblShow.Text = string.Empty;
      }

    }
    // TODO: This function is incomplete.
    protected void btnSendTurno_Click(object sender, EventArgs e)
    {
      string year, day, month; // DATE TURNO
      day = txtDateTurno.Text.ToString().Split('-')[0];
      month = txtDateTurno.Text.ToString().Split('-')[1];
      year = txtDateTurno.Text.ToString().Split('-')[2];

      //lblDateError.Text = $"TRUNO: {year} - {month} - {day}";

      string date = $"{year}-{month}-{day}";

      int dayTurno = Convert.ToInt32(ddlDaysAvailable.SelectedValue);

      FechaService fechaService = new FechaService();
      DataTable dataDay = fechaService.GetDayName(date); // Query DATENAME(WeekDay, 'date' ) ..;
      string nameDay = dataDay.Rows[0]["NameDay"].ToString();
      int numberDay = Convert.ToInt32(dataDay.Rows[0]["NumberDay"]);

      lblDateError.Text = $"Dia: {nameDay}  =  {numberDay} </br>";

      if (numberDay - 1 == dayTurno)
      {
        // We get a list from database of Dortors with id:
        // We need speciality:
        lblDateError.Text += "They are same";
      }
      //DataTable dataMonth = fechaService.GetMonthName(date);
      //lblDateError.Text += "Mes: " + dataMonth.Rows[0]["NameMonth"].ToString();
      //lblDateError.Text += " = " + dataMonth.Rows[0]["NumberMonth"].ToString();
    }
    private void Load_DaysAvailable(string legajoMedico)
    {
      MedicoService medicoService = new MedicoService();
      DataTable source = medicoService.GetDaysAvailableByLegajo(legajoMedico);
      this.BindDropDownList(ddlDaysAvailable, source, "Nombre", "Id_Dia");
    }
    private void Load_ScheduleDoctors(string legajo) // Also the function must give an Id_diasAtencion
    {
      MedicoService medicoService = new MedicoService();
      DataTable source = medicoService.GetScheduleDoctorByLegajo(legajo);
      this.BindDropDownList(ddlDoctorsSchedules, source, "Horario", "Id_hora");
    }
    private void BindDropDownList(DropDownList ddl, DataTable dataSource, string textField, string valueField)
    {
      ddl.DataSource = dataSource;
      ddl.DataTextField = textField;
      ddl.DataValueField = valueField;
      ddl.DataBind();
      ddl.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
    }

  }
}
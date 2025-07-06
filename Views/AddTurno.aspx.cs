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
    private void Load_Specialities()
    {
      EspecialidadService especialidadService = new EspecialidadService();
      DataTable source = especialidadService.GetSpecialities();
      //ddlSpecialities.DataSource = especialidadService.GetSpecialities();
      //ddlSpecialities.DataTextField = "Nombre";
      //ddlSpecialities.DataValueField = "Id_Especialidad";
      //ddlSpecialities.DataBind();
      //ddlSpecialities.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
      this.BindDropDownList(ddlSpecialities, source, "Nombre", "Id_Especialidad");
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
      //ddlSpecialityDoctors.DataSource = medicoService.GetAllDoctorsSpecialities(Id_Speciality);
      //ddlSpecialityDoctors.DataTextField = "NOMBRE COMPLETO:";
      //ddlSpecialityDoctors.DataValueField = "LegajoMedico";
      //ddlSpecialityDoctors.DataBind();
      //ddlSpecialityDoctors.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
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
    private void Load_DaysAvailable(string legajoMedico)
    {
      MedicoService medicoService = new MedicoService();
      DataTable source = medicoService.GetDaysAvailableByLegajo(legajoMedico);
      //ddlDaysAvailable.DataSource = medicoService.GetDaysAvailableByLegajo(legajoMedico);
      //ddlDaysAvailable.DataTextField = "Nombre";
      //ddlDaysAvailable.DataValueField = "Id_Dia";
      //ddlDaysAvailable.DataBind();
      //ddlDaysAvailable.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
      this.BindDropDownList(ddlDaysAvailable, source, "Nombre", "Id_Dia");
    }

    private void Load_ScheduleDoctors(string legajo) // Also the function must give an Id_diasAtencion
    {
      MedicoService medicoService = new MedicoService();
      DataTable source = medicoService.GetScheduleDoctorByLegajo(legajo);
      //ddlDoctorsSchedules.DataSource = medicoService.GetScheduleDoctorByLegajo(legajo);
      //ddlDoctorsSchedules.DataTextField = "Horario";
      //ddlDoctorsSchedules.DataValueField = "Id_Hora";
      //ddlDoctorsSchedules.DataBind();
      //ddlDoctorsSchedules.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
      this.BindDropDownList(ddlDoctorsSchedules, source, "Horario", "Id_hora");
    }

    protected void btnSendTurno_Click(object sender, EventArgs e)
    {
      string year, day, month;
      day = txtDateTurno.Text.ToString().Split('-')[0];
      month = txtDateTurno.Text.ToString().Split('-')[1];
      year = txtDateTurno.Text.ToString().Split('-')[2];

      //lblDateError.Text = $"TRUNO: {year} - {month} - {day}";

      string date = $"{year}-{month}-{day}";
      FechaService fechaService = new FechaService();
      DataTable dataDay = fechaService.GetDayName(date);
      lblDateError.Text = " Dia: " + dataDay.Rows[0]["NameDay"].ToString() + " = " + dataDay.Rows[0]["NumberDay"].ToString() + "</br>";

      DataTable dataMonth = fechaService.GetMonthName(date);
      lblDateError.Text += "Mes: " + dataMonth.Rows[0]["NameMonth"].ToString();
      lblDateError.Text += " = " + dataMonth.Rows[0]["NumberMonth"].ToString();

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


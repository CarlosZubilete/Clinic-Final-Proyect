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
      MedicoService medicoService = new MedicoService();
      ddlSpecialities.DataSource = medicoService.GetAllSpeciality();
      ddlSpecialities.DataTextField = "Nombre";
      ddlSpecialities.DataValueField = "Id_Especialidad";
      ddlSpecialities.DataBind();
      ddlSpecialities.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
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

      if (selectedId != 0)
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

      ddlSpecialityDoctors.DataSource = medicoService.GetAllDoctorsSpecialities(Id_Speciality);
      ddlSpecialityDoctors.DataTextField = "NOMBRE COMPLETO:";
      ddlSpecialityDoctors.DataValueField = "LegajoMedico";
      ddlSpecialityDoctors.DataBind();
      ddlSpecialityDoctors.Items.Insert(0, new ListItem(" -- Select -- ", "0"));

      //lblShow.Text += $"Doctor: {ddlSpecialityDoctors.SelectedValue}";
    }
    protected void ddlSpecialityDoctors_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedSpecialityDoctor = Convert.ToInt32(ddlSpecialityDoctors.SelectedValue);

      if (selectedSpecialityDoctor != 0)
      {
        lblShow.Text = $"Espcialidad seleccionada: {ddlSpecialities.SelectedValue} </br>";
        lblShow.Text += $"Legajo Doctor: {ddlSpecialityDoctors.SelectedValue}";
        Load_DaysAvailable(ddlSpecialityDoctors.SelectedValue);
      }
      else
      {
        ddlSpecialityDoctors.Items.Clear();
        ddlSpecialityDoctors.Items.Insert(0, new ListItem(" -- Select --", "0"));
        ddlSpecialityDoctors.Text = string.Empty; 
      }
    }
    private void Load_DaysAvailable(string legajoMedico)
    {
      MedicoService medicoService = new MedicoService();
      ddlDaysAvailable.DataSource = medicoService.GetDaysAvailableByLegajo(legajoMedico);
      ddlDaysAvailable.DataTextField = "Nombre";
      ddlDaysAvailable.DataValueField = "Id_DiasAtencion";
      ddlDaysAvailable.DataBind();
      ddlDaysAvailable.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
    }


    //protected void btnSendTurno_Click(object sender, EventArgs e)
    //{
    //  int selectedSpeciality = Convert.ToInt32(ddlSpecialities.SelectedValue);
    //  int selectedSpecialityDoctor = Convert.ToInt32(ddlSpecialityDoctors.SelectedValue);

    //  if (selectedSpeciality != 0 && selectedSpecialityDoctor != 0)
    //  {
    //    lblShow.Text = $"Espcialidad seleccionada: {ddlSpecialities.SelectedValue} </br>";
    //    lblShow.Text += $"Legajo Doctor: {ddlSpecialityDoctors.SelectedValue}";
    //    Load_DaysAvailable(ddlSpecialityDoctors.SelectedValue);
    //  }
    //}
  }
}

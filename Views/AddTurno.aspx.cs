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

    protected void ddlSpecialities_SelectedIndexChanged(object sender, EventArgs e)
    {
      //lblShow.Text = $"Espcialidad seleccionada: {ddlSpecialities.SelectedItem.Text}"; 

      lblShow.Text = $"Espcialidad seleccionada: {ddlSpecialities.SelectedValue}";
      int selectedId = Convert.ToInt32(ddlSpecialities.SelectedValue);

      if (selectedId != 0)
      {
        Load_Specialities_Doctors(selectedId);
        // lblShowMessage.Text = $"Provincia seleccionada: {ddlProvincies.SelectedItem.Text}";
      }
      else
      {
        ddlSpecialities.Items.Clear();
        ddlSpecialities.Items.Insert(0, new ListItem(" -- Select --", "0"));
        ddlSpecialities.Text = string.Empty;
      }
    }
    private void Load_Specialities()
    {
      //EspecialidadService especialidadService = new EspecialidadService(); 
      MedicoService medicoService = new MedicoService();
      ddlSpecialities.DataSource = medicoService.GetAllSpeciality();
      ddlSpecialities.DataTextField = "Nombre";
      ddlSpecialities.DataValueField = "Id_Especialidad";
      ddlSpecialities.DataBind();
      ddlSpecialities.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
    }
    private void Load_Specialities_Doctors(int Id_Speciality)
    {
      MedicoService medicoService = new MedicoService();

      ddlSpecialityDoctors.DataSource = medicoService.GetAllDoctorsSpecialities(Id_Speciality);
      ddlSpecialityDoctors.DataTextField = "NOMBRE COMPLETO:";
      ddlSpecialityDoctors.DataValueField = "LegajoMedico";
      ddlSpecialityDoctors.DataBind();
      ddlSpecialityDoctors.Items.Insert(0, new ListItem(" -- Select -- ", "0"));

    }
  }
}
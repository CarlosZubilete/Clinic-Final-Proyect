using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business;
using Entities;

namespace Views
{
  public partial class AddMedico : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        if (Session["DataPersona"] != null)
        {
          DataTable dataPerson = (DataTable)Session["DataPersona"];

          lblDNI.Text = dataPerson.Rows[0]["DNI"].ToString();
          lblFullName.Text = dataPerson.Rows[0]["Nombre"].ToString() + " " + dataPerson.Rows[0]["Apellido"].ToString();
          lblBirthdate.Text = dataPerson.Rows[0]["FechaNacimiento"].ToString();
        }

        Load_Speciality();
        Load_Horarios();
        Load_Dias();
      }
    }

    private void Load_Speciality()
    {
      MedicoService medicoService = new MedicoService();

      ddlSpecialy.DataSource = medicoService.GetAllSpeciality();
      ddlSpecialy.DataTextField = "Nombre";
      ddlSpecialy.DataValueField = "Id_Especialidad";
      ddlSpecialy.DataBind();

      ddlSpecialy.Items.Insert(0, new ListItem("-- Select --", "0"));
    }
    private void Load_Horarios()
    {
      MedicoService medicoService = new MedicoService();

      ddlHorariosAtencion.DataSource = medicoService.GetHorariosAtencion();
      ddlHorariosAtencion.DataTextField = "Descripcion";
      ddlHorariosAtencion.DataValueField = "Id_HorarioAtencion";
      ddlHorariosAtencion.DataBind();

      ddlHorariosAtencion.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
    }
    private void Load_Dias()
    {
      MedicoService medicoService = new MedicoService();

      ddlDiasAtencion.DataSource = medicoService.GetDiasAtencion();
      ddlDiasAtencion.DataTextField = "Descripcion";
      ddlDiasAtencion.DataValueField = "Id_DiaAtencion";
      ddlDiasAtencion.DataBind();

      ddlDiasAtencion.Items.Insert(0, new ListItem(" -- Select -- ", "0"));
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      /*
      string query;
      query = $"Legajo: {txtLegajo.Text.ToString().Trim()}";
      query += $"Especialidad: {ddlSpecialy.SelectedValue}";
      query += $"Dias Laborales: {ddlDiasAtencion.SelectedValue}";
      query += $"Horarios Atencion : {ddlHorariosAtencion.SelectedValue}";

      lblShowData.Text = query;
      */

      Medico medico = BuiltMedico();
      MedicoService service = new MedicoService();

      if (service.ExistsLegajo(medico.Legajo))
      {
        lblShowData.Text = "Legajo has already exists"; 
        return; 
      }
      if (service.AddMedico(ref medico))
      {
        lblShowData.Text = "Can add the register successfully";
        CleanControls();
      }

    }
    private Medico BuiltMedico()
    {
      string legajo = txtLegajo.Text.ToString().Trim();
      string especialidad = ddlSpecialy.SelectedValue.ToString();
      string diasLaborales = ddlDiasAtencion.SelectedValue.ToString();
      string horariosLaborres = ddlHorariosAtencion.SelectedValue.ToString();
      string dni = lblDNI.Text.ToString();

      Medico medico = new Medico { Legajo = legajo, DNI = dni, Speciality = Convert.ToInt32(especialidad), Dias = Convert.ToInt32(diasLaborales), Horas = Convert.ToInt32(horariosLaborres) };

      return medico;
    }
    private void CleanControls()
    {
      txtLegajo.Text = string.Empty;
      ddlSpecialy.SelectedIndex = 0;
      ddlDiasAtencion.SelectedIndex = 0;
      ddlHorariosAtencion.SelectedIndex = 0;
    }

  }
}
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
        if(Session["DataPersona"] != null)
        {
          DataTable dataPerson = (DataTable)Session["DataPersona"];

          lblDNI.Text = dataPerson.Rows[0]["DNI"].ToString();
          lblFullName.Text = dataPerson.Rows[0]["Nombre"].ToString() + " " + dataPerson.Rows[0]["Apellido"].ToString();
          lblBirthdate.Text = dataPerson.Rows[0]["FechaNacimiento"].ToString(); 
        }

        this.Load_Speciality();
      }
    }

    private void Load_Speciality()
    {
      MedicoService medicoService = new MedicoService();

      ddlSpecialy.DataSource = medicoService.GetSpeciality();
      ddlSpecialy.DataTextField= "Nombre";
      ddlSpecialy.DataValueField = "Id_Especialidad";

      ddlSpecialy.DataBind();
      ddlSpecialy.Items.Insert(0, new ListItem("-- Select --", "0"));
    }
  }
}